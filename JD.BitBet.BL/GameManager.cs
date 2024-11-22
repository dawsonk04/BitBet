using JD.BitBet.BL.Models;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public static GameState State { get; private set; }
        public static GameStateManager GameStateManager { get; private set; }
        public static HandManager handManager { get; private set; }
        public static CardManager cardManager { get; private set; }

        private static Deck _deck;

        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public GameManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger)
        {
            State = new GameState();
            GameStateManager = new GameStateManager(logger, options);
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
                return await base.InsertAsync(row,
                    e => e.GameResult == game.GameResult, rollback);
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
        public static async Task<GameState> StartNewGame()
        {

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

            // Assign to State
            State.playerHand = playerHand;
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
            playerCard1.handId = playerHand.Id;
            playerCard1.Id = Guid.NewGuid();
            playerCard2.handId = playerHand.Id;
            playerCard2.Id = Guid.NewGuid();
            dealerCard1.handId = dealerHand.Id;
            dealerCard1.Id = Guid.NewGuid();
            dealerCard2.handId = dealerHand.Id;
            dealerCard2.Id = Guid.NewGuid();

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
                State.Message = "Blackjack! Player wins.";
                State.isGameOver = true;
            }

            // Insert Hands and Cards into Database
            await handManager.InsertAsync(playerHand);
            await handManager.InsertAsync(dealerHand);
            await cardManager.InsertAsync(playerCard1);
            await cardManager.InsertAsync(playerCard2);
            await cardManager.InsertAsync(dealerCard1);
            await cardManager.InsertAsync(dealerCard2);

            // Save Game State
            await GameStateManager.InsertAsync(State);

            return State;
        }

        public static int CalculateHandValue(List<Card> hand)
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (card.Rank == Rank.Ace)
                    aceCount++;
                value += (int)card.Rank;
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
        public enum handAction
        {
            Hit, Stand, Double, Split
        }
        public void Hit()
        {
            if (State.isGameOver || !State.isPlayerTurn)
            {
                State.Message = "Invalid action. The game is over or it's not your turn.";
                return;
            }

            State.playerHand.Cards.Add(_deck.Deal());
            State.playerHandVal = CalculateHandValue(State.playerHand.Cards);

            if (State.playerHandVal > 21)
            {
                State.isGameOver = true;
                State.Message = "Player busts! Dealer wins.";
            }
            else if (State.playerHandVal == 21)
            {
                State.Message = "Player hits 21!";
            }
            else
            {
                State.Message = "Player hits.";
            }
        }

        public void Stand()
        {
            if (State.isGameOver || !State.isPlayerTurn)
            {
                State.Message = "Invalid action. The game is over or it's not your turn.";
                return;
            }

            State.isPlayerTurn = false;
            PerformDealerTurn();
        }

        public void PerformDealerTurn()
        {
            State.Message = "Dealer's turn.";

            while (State.dealerHandVal < 17)
            {
                State.dealerHand.Cards.Add(_deck.Deal());
                State.dealerHandVal = CalculateHandValue(State.dealerHand.Cards);
            }
            DetermineWinner();
        }

        public void DetermineWinner()
        {
            if (State.dealerHandVal > 21)
            {
                State.isGameOver = true;
                State.Message = "Dealer busts! Player wins.";
                return;
            }

            if (State.playerHandVal > State.dealerHandVal)
            {
                State.isGameOver = true;
                State.Message = "Player wins!";
            }
            else if (State.playerHandVal < State.dealerHandVal)
            {
                State.isGameOver = true;
                State.Message = "Dealer wins!";
            }
            else
            {
                State.isGameOver = true;
                State.Message = "Push! It's a tie.";
            }
        }

        public void Double(Guid handId)
        {
            if (State.isGameOver || !State.isPlayerTurn)
            {
                State.Message = "Invalid action. The game is over or it's not your turn.";
                return;
            }

            // Double the bet (not implemented here but tracked in your game logic)
            State.playerHand.Cards.Add(_deck.Deal());
            State.playerHandVal = CalculateHandValue(State.playerHand.Cards);

            if (State.playerHandVal > 21)
            {
                State.isGameOver = true;
                State.Message = "Player busts after doubling!";
            }
            else
            {
                Stand(); // Automatically ends the turn.
            }
        }

        public void Split(Guid handId)
        {

            //      State.playerHand = cardManager.LoadByHandId(handId);

            if (State.playerHand.Cards.Count != 2 || State.playerHand.Cards[0].Rank != State.playerHand.Cards[1].Rank)
            {
                State.Message = "Cannot split this hand.";
                return;
            }
            var hand1 = new List<Card> { State.playerHand.Cards[0], _deck.Deal() };
            var hand2 = new List<Card> { State.playerHand.Cards[1], _deck.Deal() };

            State.playerHands = new List<List<Card>> { hand1, hand2 };
            State.Message = "Player splits their hand.";
        }


    }
}
