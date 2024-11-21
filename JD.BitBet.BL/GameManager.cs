using JD.BitBet.BL.Models;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public static GameState State { get; private set; }
        public static Deck _deck;
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public GameManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
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
        public static void StartNewGame()
        {
            State = new GameState();
            State.dealerHand = new List<Card>();
            State.playerHand = new List<Card>();

            State.isPlayerTurn = true;
            State.isGameOver = false;
            State.Message = "Game Started!";

            _deck = new Deck();
            _deck.Shuffle();

            State.playerHand.Add(_deck.Deal());
            State.playerHand.Add(_deck.Deal());
            State.dealerHand.Add(_deck.Deal());
            State.dealerHand.Add(_deck.Deal());

            State.playerHandVal = CalculateHandValue(State.playerHand);
            State.dealerHandVal = CalculateHandValue(State.dealerHand);

            if (State.playerHandVal == 21)
            {
                State.Message = "Blackjack! Player wins.";
                State.isGameOver = true;
            }

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
        //public static GameResult CompleteGame()
        //{
        //    int BlackjackValue = 21;
        //    GameResult result;
        //    int dealerValue = CalculateHandValue(_dealerHand);
        //    int playerValue = CalculateHandValue(_playerHand);

        //    //Player Plays
        //    //Todo: remove when UI is implemented
        //    if (dealerValue != BlackjackValue)
        //    {
        //        while (playerValue < 17)
        //        {
        //            _playerHand.Add(_deck.Deal());
        //            playerValue = CalculateHandValue(_playerHand);
        //        }
        //        if (playerValue == BlackjackValue)
        //        {
        //            result = GameResult.PlayerBlackjack;
        //        }
        //        else if (playerValue > BlackjackValue)
        //        {
        //            result = GameResult.PlayerBust;
        //        }
        //        else
        //        {
        //            result = GameResult.PlayerStand;
        //        }
        //    }
        //    else
        //    {
        //        if (playerValue == BlackjackValue)
        //        {
        //            result = GameResult.Push;
        //        }
        //        else
        //        {
        //            result = GameResult.DealerWins;
        //        }
        //    }

        //    //Check To see if dealer plays
        //    if (result == GameResult.PlayerBust)
        //    {
        //        result = GameResult.DealerWins;
        //    }
        //    else if (result == GameResult.PlayerBlackjack)
        //    {
        //        //Todo: Add Muiltiplier for winnings
        //        result = GameResult.PlayerWins;
        //    }
        //    else
        //    {
        //        //Dealer Plays
        //        while (dealerValue < 17)
        //        {
        //            _dealerHand.Add(_deck.Deal());
        //            dealerValue = CalculateHandValue(_dealerHand);
        //        }
        //        if (dealerValue == BlackjackValue)
        //        {
        //            result = GameResult.DealerWins;
        //        }
        //        if (dealerValue > BlackjackValue)
        //        {
        //            result = GameResult.PlayerWins;
        //        }
        //        //Both players stand
        //        else
        //        {
        //            if (dealerValue > playerValue)
        //            {
        //                result = GameResult.DealerWins;
        //            }
        //            else if (dealerValue == playerValue)
        //            {
        //                result = GameResult.Push;
        //            }
        //            else
        //            {
        //                result = GameResult.PlayerWins;
        //            }
        //        }
        //    }
        //    _playerHand.Clear();
        //    _dealerHand.Clear();
        //    return result;
        //}

        public void Hit()
        {
            if (State.isGameOver || !State.isPlayerTurn)
            {
                State.Message = "Invalid action. The game is over or it's not your turn.";
                return;
            }

            State.playerHand.Add(_deck.Deal());
            State.playerHandVal = CalculateHandValue(State.playerHand);

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
                State.dealerHand.Add(_deck.Deal());
                State.dealerHandVal = CalculateHandValue(State.dealerHand);
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
            State.playerHand.Add(_deck.Deal());
            State.playerHandVal = CalculateHandValue(State.playerHand);

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
            if (State.playerHand.Count != 2 || State.playerHand[0].Rank != State.playerHand[1].Rank)
            {
                State.Message = "Cannot split this hand.";
                return;
            }

            var hand1 = new List<Card> { State.playerHand[0], _deck.Deal() };
            var hand2 = new List<Card> { State.playerHand[1], _deck.Deal() };

            State.playerHands = new List<List<Card>> { hand1, hand2 };
            State.Message = "Player splits their hand.";
        }


    }
}
