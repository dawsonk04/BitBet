﻿using JD.BitBet.BL.Models;
using Mono.TextTemplating;
using static JD.BitBet.PL.Entities.tblCard;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public enum GameResult
        {
            InProgress,
            PlayerBlackjack,
            PlayerBust,
            PlayerWins,
            PlayerStand,
            DealerStand,
            DealerBlackJack,
            DealerBust,
            DealerWins,
            Push
        }
        public enum handAction
        {
            Hit, Stand, Double, Split
        }

        public static GameStateManager gameStateManager { get; private set; }
        public static HandManager handManager { get; private set; }
        public static CardManager cardManager { get; private set; }
        public static WalletManager walletManager { get; private set; }
        public static UserManager userManager { get; set; }

        private static Deck _deck;

        private const string NOTFOUND_message = "Row does not exist";
        public GameManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger)
        {
            _deck = new Deck();
            gameStateManager = new GameStateManager(logger, options);
            handManager = new HandManager(logger, options);
            cardManager = new CardManager(logger, options);
            walletManager = new WalletManager(logger,options);
            userManager = new UserManager(logger, options);
        }

        public GameManager(DbContextOptions<BitBetEntities> options) : base(options) { }
        public GameManager() { }
        public async Task<Guid> InsertAsync(Game game, bool rollback = false)
        {
            try
            {
                tblGame row = Map<Game, tblGame>(game);
                return await base.InsertAsync(row, null, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> UpdateAsync(Game game, bool rollback = false)
        {
            try
            {
                tblGame row = Map<Game, tblGame>(game);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<Game>> LoadAsync()
        {
            try
            {
                List<Game> list = new List<Game>();
                (await base.LoadAsync())
                    .ForEach(e => list.Add(Map<tblGame, Game>(e)));
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Game> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblGame> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblGame, Game>(row[0]);
                else
                    throw new Exception("No Row");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<GameState>> StartNewGame(Game game)
        {

            List<GameState> states = new List<GameState>();            
            gameStateManager = new GameStateManager(options);
            handManager = new HandManager(options);
            cardManager = new CardManager(options);

            _deck = new Deck();
            _deck.Shuffle();

            Hand dealerHand = new Hand
            {
                Id = Guid.NewGuid(),
                Result = 0,
                Cards = new List<Card>()
            };

            Card dealerCard = new Card();
            dealerCard = _deck.Deal();
            dealerCard.HandId = dealerHand.Id;

            await handManager.InsertAsync(dealerHand);
            await cardManager.InsertAsync(dealerCard);

            foreach (var user in game.Users)
            {

                GameState State = new GameState();
                State.dealerHandId = dealerHand.Id;
                State.dealerHand = dealerHand;
                State.dealerHand.Cards.Add(dealerCard);
                State.dealerHandVal = CalculateHandValue(State.dealerHand.Cards);
                State.GameId = game.Id;
                State.UserId = user.Id;
                User dbUser = await userManager.LoadByIdAsync(State.UserId);
                State.Id = Guid.NewGuid();
                Hand playerHand = new Hand
                {
                    Id = Guid.NewGuid(),
                    Result = 0,
                    Cards = new List<Card>()
                };

                State.playerHand = playerHand;
                State.playerHandId = playerHand.Id;
                State.isGameOver = false;
                State.isPlayerTurn = true;

                Card playerCard1 = _deck.Deal();
                Card playerCard2 = _deck.Deal();

                playerCard1.HandId = playerHand.Id;
                playerCard2.HandId = playerHand.Id;

                State.playerHand.Cards.Add(playerCard1);
                State.playerHand.Cards.Add(playerCard2);
                State.BetAmount = dbUser.BetAmount;
                State.playerHandVal = CalculateHandValue(State.playerHand.Cards);

                if (State.playerHandVal == 21)
                {
                    State.message = "Blackjack! Player wins.";
                    State.isGameOver = true;
                }
                else
                {
                    State.message = "Game Initialized";
                }
                await handManager.InsertAsync(playerHand);
                await cardManager.InsertAsync(playerCard1);
                await cardManager.InsertAsync(playerCard2);
                await gameStateManager.InsertAsync(State);
                states.Add(await populateGameState(State));
            }

            return states;
        }
        public static int CalculateHandValue(List<Card> hand)
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (card.rank == Rank.Ace)
                    aceCount++;
                value += (int)card.rank;
            }

            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }
        public async Task<GameState> populateGameState(GameState state)
        {

            Wallet userWallet = await walletManager.LoadByUserIdAsync(state.UserId);
            GameState dbGamestate = await gameStateManager.LoadByIdAsync(state.Id);
            dbGamestate.dealerHand = await handManager.LoadByIdAsync(state.dealerHandId);
            dbGamestate.playerHand = await handManager.LoadByIdAsync(state.playerHandId);
            dbGamestate.playerHand.Cards = await cardManager.LoadByHandId(state.playerHandId);
            dbGamestate.dealerHand.Cards = await cardManager.LoadByHandId(state.dealerHandId);
            dbGamestate.playerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.playerHandId));
            await gameStateManager.UpdateAsync(dbGamestate);

            if (dbGamestate.playerHandVal > 21)
            {
                dbGamestate.isGameOver = true;
                dbGamestate.message = "Player busts! Dealer wins.";
                await gameStateManager.UpdateAsync(dbGamestate);
            }
            else if (dbGamestate.playerHandVal == 21)
            {
                userWallet.Balance += dbGamestate.BetAmount * 2;
                dbGamestate.message = "Player hits 21!";
                dbGamestate.isGameOver = true;
                await gameStateManager.UpdateAsync(dbGamestate);
            }
            else
            {
                dbGamestate.message = "Player hits.";
                await gameStateManager.UpdateAsync(dbGamestate);
            }
            return dbGamestate;
        }
        public async Task<GameState> Hit(GameState state)
        {

            if (state.isGameOver || !state.isPlayerTurn)
            {
                state.message = "Invalid action. The game is over or it's not your turn.";
                await gameStateManager.UpdateAsync(state);
                return state;
            }

            Card newCard = new Card();
            _deck.Shuffle();
            newCard = _deck.Deal();
            newCard.Id = Guid.NewGuid();
            newCard.HandId = state.playerHandId;
            state.playerHand = await handManager.LoadByIdAsync(state.playerHandId);
            state.playerHand.Cards = await cardManager.LoadByHandId(state.playerHandId);
            state.playerHand.Cards.Add(newCard);
            await cardManager.InsertAsync(newCard);
            return await populateGameState(state);
        }
        public async Task<GameState> Stand(GameState state)
        {
            if (state.isGameOver || !state.isPlayerTurn)
            {
                state.message = "Invalid action. The game is over or it's not your turn.";
                await gameStateManager.UpdateAsync(state);
                return state;
            }
            state.isGameOver = true;
            state.isPlayerTurn = false;
            await gameStateManager.UpdateAsync(state);

            return await populateGameState(state);
        }

        public async Task<List<GameState>> PerformDealerTurn(List<GameState> states)
        {
            while (states[0].dealerHandVal < 17)
            {
                Card newCard = new Card();
                _deck.Shuffle();
                newCard = _deck.Deal();

                newCard.HandId = states[0].dealerHandId;
                await cardManager.InsertAsync(newCard);

                foreach (GameState state in states)
                {
                    state.dealerHand = await handManager.LoadByIdAsync(state.dealerHandId);
                    state.dealerHand.Cards = await cardManager.LoadByHandId(state.dealerHandId);
                    state.dealerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.dealerHandId));
                    state.message = "Dealer's turn.";
                }
            }
            return await DetermineWinner(states);
        }

        public async Task<List<GameState>> DetermineWinner(List<GameState> states)
        {
            foreach (GameState state in states)
            {
                User user = await userManager.LoadByIdAsync(state.UserId);
                Wallet userWallet = await walletManager.LoadByUserIdAsync(state.UserId);
                state.BetAmount = user.BetAmount;
                state.playerHand = await handManager.LoadByIdAsync(state.playerHandId);
                if (state.dealerHandVal > 21)
                {
                    state.isGameOver = true;
                    state.message = "Dealer busts! Player wins.";
                    userWallet.Balance += state.BetAmount * 2;
                    state.playerHand.Result = state.BetAmount * 2;
                    await walletManager.UpdateAsync(userWallet);
                    await gameStateManager.UpdateAsync(state);
                }
                if (state.playerHandVal > state.dealerHandVal && state.playerHandVal <= 21)
                {
                    state.isGameOver = true;
                    state.message = "Player wins!";
                    userWallet.Balance += state.BetAmount * 2;
                    state.playerHand.Result = state.BetAmount * 2;
                    await walletManager.UpdateAsync(userWallet);
                    await gameStateManager.UpdateAsync(state);
                }
                else if (state.playerHandVal < state.dealerHandVal && state.dealerHandVal <= 21)
                {
                    state.isGameOver = true;
                    state.message = "Dealer wins!";
                    await walletManager.UpdateAsync(userWallet);
                    await gameStateManager.UpdateAsync(state);
                }
                else if(state.dealerHandVal == state.playerHandVal)
                {
                    state.isGameOver = true;
                    state.message = "Push! It's a tie.";
                    userWallet.Balance += state.BetAmount;
                    await walletManager.UpdateAsync(userWallet);
                    await gameStateManager.UpdateAsync(state);
                }
            }
            return states;
        }
        public async Task<GameState> Double(GameState state)
        {
            if (state.isGameOver || !state.isPlayerTurn)
            {
                state.message = "Invalid action. The game is over or it's not your turn.";
                return state;
            }
            User user = await userManager.LoadByIdAsync(state.UserId);
            Wallet userWallet = await walletManager.LoadByUserIdAsync(state.UserId);
            state.BetAmount = user.BetAmount * 2;
            user.BetAmount = state.BetAmount;
            userWallet.Balance -= state.BetAmount;
            await userManager.UpdateAsync(user);
            await walletManager.UpdateAsync(userWallet);
            Card card = new Card();
            _deck.Shuffle();
            card = _deck.Deal();
            state.playerHand = await handManager.LoadByIdAsync(state.playerHandId);
            state.playerHand.Cards = await cardManager.LoadByHandId(state.playerHandId);
            state.playerHand.Cards.Add(card);
            card.HandId = state.playerHandId;
            await cardManager.InsertAsync(card);
            state.playerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.playerHandId));
            state.BetAmount *= 2;

            return await Stand(state);
        }

    }
}
