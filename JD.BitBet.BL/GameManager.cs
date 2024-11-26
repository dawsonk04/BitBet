using JD.BitBet.BL.Models;
using static JD.BitBet.PL.Entities.tblCard;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public static GameState State { get; private set; }
        public static GameStateManager gameStateManager { get; private set; }
        public static HandManager handManager { get; private set; }
        public static CardManager cardManager { get; private set; }

        private static Deck _deck;

        private const string NOTFOUND_message = "Row does not exist";
        public GameManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger)
        {
            State = new GameState();
            gameStateManager = new GameStateManager(logger, options);
            handManager = new HandManager(logger, options);
            cardManager = new CardManager(logger, options);
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
        //public static void StartNewGame1()
        //{
        //    _deck = new Deck();
        //    _playerHand = new List<Card>();
        //    _dealerHand = new List<Card>();
        //    _deck.Shuffle();
        //    _playerHand.Add(_deck.Deal());
        //    _playerHand.Add(_deck.Deal());
        //    _dealerHand.Add(_deck.Deal());
        //    _dealerHand.Add(_deck.Deal());
        //}
        public async Task<GameState> StartNewGame()
        {
            State = new GameState();
            gameStateManager = new GameStateManager(options);
            handManager = new HandManager(options);
            cardManager = new CardManager(options);

            State.Id = Guid.NewGuid();
            // Create Player and Dealer Hands
            Hand playerHand = new Hand
            {
                Id = Guid.NewGuid(),
                BetAmount = 10,
                Result = 0,
                Cards = new List<Card>()
            };

            Hand dealerHand = new Hand
            {
                Id = Guid.NewGuid(),
                BetAmount = 0,
                Result = 0,
                Cards = new List<Card>()
            };
            State.playerHands = new List<Hand>();
            // Assign to State
            State.playerHand = playerHand;
            State.playerHands.Add(playerHand);
            State.dealerHand = dealerHand;
            State.playerHandId = playerHand.Id;
            State.dealerHandId = dealerHand.Id;
            State.isGameOver = false;
            State.isPlayerTurn = true;

            // Initialize Deck
            _deck = new Deck();
            _deck.Shuffle();

            // Deal Cards
            Card playerCard1 = _deck.Deal();
            Card playerCard2 = _deck.Deal();
            Card dealerCard1 = _deck.Deal();
            Card dealerCard2 = _deck.Deal();

            // Assign Hand IDs
            playerCard1.HandId = playerHand.Id;
            playerCard2.HandId = playerHand.Id;
            dealerCard1.HandId = dealerHand.Id;
            dealerCard2.HandId = dealerHand.Id;

            // Add Cards to State
            State.playerHand.Cards.Add(playerCard1);
            State.playerHand.Cards.Add(playerCard2);
            State.dealerHand.Cards.Add(dealerCard1);
            State.dealerHand.Cards.Add(dealerCard2);

            // Calculate Hand Values
            State.playerHandVal = CalculateHandValue(State.playerHand.Cards);
            State.dealerHandVal = CalculateHandValue(State.dealerHand.Cards);
            // Check for Blackjack
            if (State.playerHandVal == 21)
            {
                State.message = "Blackjack! Player wins.";
                State.isGameOver = true;
            }
            else
            {
                State.message = "Game Initialized";
            }

            await handManager.InsertAsync(dealerHand);
            await handManager.InsertAsync(playerHand);
            await cardManager.InsertAsync(playerCard1);
            await cardManager.InsertAsync(playerCard2);
            await cardManager.InsertAsync(dealerCard1);
            await cardManager.InsertAsync(dealerCard2);
            await gameStateManager.InsertAsync(State);

            // Save Game State
            return await populateGameState(State);
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
        public async Task<GameState> populateGameState(GameState state)
        {
            GameState dbGamestate = await gameStateManager.LoadByIdAsync(state.Id);
            dbGamestate.dealerHand = await handManager.LoadByIdAsync(state.dealerHandId);
            dbGamestate.playerHand = await handManager.LoadByIdAsync(state.playerHandId);
            dbGamestate.playerHand.Cards = await cardManager.LoadByHandId(state.playerHandId);
            dbGamestate.dealerHand.Cards = await cardManager.LoadByHandId(state.dealerHandId);
            dbGamestate.playerHands = new List<Hand>();

            int counter = 0;
            foreach (var hand in state.playerHands)
            {
                dbGamestate.playerHands.Add(await handManager.LoadByIdAsync(hand.Id));

                foreach (var card in state.playerHands[counter].Cards)
                    dbGamestate.playerHands[counter].Cards = await cardManager.LoadByHandId(hand.Id);
                counter++;
            }
            dbGamestate.playerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.playerHandId));

            if (dbGamestate.playerHandVal > 21)
            {
                dbGamestate.isGameOver = true;
                dbGamestate.message = "Player busts! Dealer wins.";
            }
            else if (dbGamestate.playerHandVal == 21)
            {
                dbGamestate.message = "Player hits 21!";
            }
            else
            {
                dbGamestate.message = "Player hits.";
            }
            return dbGamestate;
        }
        public enum handAction
        {
            Hit, Stand, Double, Split
        }

        public async Task<GameState> Hit(GameState state)
        {
            if (state.isGameOver || !state.isPlayerTurn)
            {
                state.message = "Invalid action. The game is over or it's not your turn.";
                return state;
            }

            Card newCard = _deck.Deal();
            newCard.Id = Guid.NewGuid();
            newCard.HandId = state.playerHandId;
            state.playerHand.Cards.Add(newCard);

            await cardManager.InsertAsync(newCard);
            await gameStateManager.UpdateAsync(state);

            return await populateGameState(state);
        }
        public async Task<GameState> Stand(GameState state)
        {
            if (state.isGameOver || !state.isPlayerTurn)
            {
                State.message = "Invalid action. The game is over or it's not your turn.";
                return state;
            }

            State.isPlayerTurn = false;
            return await PerformDealerTurn(state);
        }

        public async Task<GameState> PerformDealerTurn(GameState state)
        {
            state.message = "Dealer's turn.";

            while (state.dealerHandVal < 17)
            {
                Card card = _deck.Deal();
                state.dealerHand.Cards.Add(card);
                card.HandId = state.dealerHandId;
                await cardManager.InsertAsync(card);
                state.dealerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.dealerHandId));
            }
            return await DetermineWinner(state);
        }

        public async Task<GameState> DetermineWinner(GameState state)
        {
            if (state.dealerHandVal > 21)
            {
                state.isGameOver = true;
                state.message = "Dealer busts! Player wins.";
                await gameStateManager.UpdateAsync(state);
                return state;
            }
            if (state.playerHandVal > state.dealerHandVal)
            {
                state.isGameOver = true;
                state.message = "Player wins!";
                await gameStateManager.UpdateAsync(state);
                return state;
            }
            else if (state.playerHandVal < state.dealerHandVal)
            {
                state.isGameOver = true;
                state.message = "Dealer wins!";
                await gameStateManager.UpdateAsync(state);
                return state;
            }
            else
            {
                state.isGameOver = true;
                state.message = "Push! It's a tie.";
                await gameStateManager.UpdateAsync(state);
                return state;
            }
        }

        public async Task<GameState> Double(GameState state)
        {
            if (state.isGameOver || !state.isPlayerTurn)
            {
                state.message = "Invalid action. The game is over or it's not your turn.";
                return state;
            }


            Card card = _deck.Deal();
            state.playerHand.Cards.Add(card);
            card.HandId = state.playerHandId;
            await cardManager.InsertAsync(card);
            state.playerHandVal = CalculateHandValue(await cardManager.LoadByHandId(state.playerHandId));

            state.playerHand.BetAmount *= 2;

            return await Stand(state);
        }

        public void Split(Guid handId)
        {

            //      State.playerHand = cardManager.LoadByHandId(handId);

            if (State.playerHand.Cards.Count != 2 || State.playerHand.Cards[0].rank != State.playerHand.Cards[1].rank)
            {
                State.message = "Cannot split this hand.";
                return;
            }
            var hand1 = new List<Card> { State.playerHand.Cards[0], _deck.Deal() };
            var hand2 = new List<Card> { State.playerHand.Cards[1], _deck.Deal() };

            //State.playerHands = new List<Hand> { hand1, hand2 };
            State.message = "Player splits their hand.";
        }


    }
}
