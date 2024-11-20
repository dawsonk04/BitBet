using JD.BitBet.BL.Models;
using System.ComponentModel;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public static List<Card> _playerHand { get; set; }
        public static List<Card> _dealerHand {get; set; }   
        public static Deck _deck;
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public GameManager( ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
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
        public static void StartNewGame()
        {
            _deck = new Deck();
            _playerHand = new List<Card>();
            _dealerHand = new List<Card>();
            _deck.Shuffle();
            _playerHand.Add(_deck.Deal());
            _playerHand.Add(_deck.Deal());
            _dealerHand.Add(_deck.Deal());
            _dealerHand.Add(_deck.Deal());
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
        public static GameResult CompleteGame()
        {     
            int BlackjackValue = 21;
            GameResult result;
            int dealerValue = CalculateHandValue(_dealerHand);
            int playerValue = CalculateHandValue(_playerHand);

            //Player Plays
            //Todo: remove when UI is implemented
            if (dealerValue != BlackjackValue)
            {
                while (playerValue < 17)
                {
                    _playerHand.Add(_deck.Deal());
                    playerValue = CalculateHandValue(_playerHand);
                }
                if (playerValue == BlackjackValue)
                {
                    result = GameResult.PlayerBlackjack;
                }
                else if (playerValue > BlackjackValue)
                {
                    result = GameResult.PlayerBust;
                }
                else
                {
                    result = GameResult.PlayerStand;
                }
            }
            else
            {
                if (playerValue == BlackjackValue)
                {
                    result = GameResult.Push;
                }
                else
                {
                    result = GameResult.DealerWins;
                }
            }

            //Check To see if dealer plays
            if (result == GameResult.PlayerBust)
            {
                result = GameResult.DealerWins;
            }
            else if (result == GameResult.PlayerBlackjack)
            {
                //Todo: Add Muiltiplier for winnings
                result = GameResult.PlayerWins;
            }
            else
            {
                //Dealer Plays
                while (dealerValue < 17)
                {
                    _dealerHand.Add(_deck.Deal());
                    dealerValue = CalculateHandValue(_dealerHand);
                }
                if (dealerValue == BlackjackValue)
                {
                    result = GameResult.DealerWins;
                }
                if (dealerValue > BlackjackValue)
                {
                    result = GameResult.PlayerWins;
                }
                //Both players stand
                else
                {
                    if (dealerValue > playerValue)
                    {
                        result = GameResult.DealerWins;
                    }
                    else if(dealerValue == playerValue)
                    {
                        result = GameResult.Push;
                    }
                    else
                    {
                        result = GameResult.PlayerWins;
                    }
                }
            }
            _playerHand.Clear();
            _dealerHand.Clear();
            return result;
        }

        public void Hit(List<Cards> hand)
        {
            
        }

        public void Stand(Guid handId)
        {

        }

        public void Double(Guid handId)
        {

        }

        public void Split(Guid handId)
        {

        }


    }
}
