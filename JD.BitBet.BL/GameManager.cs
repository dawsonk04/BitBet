using JD.BitBet.BL.Models;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public static Deck _deck;
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public GameManager(DbContextOptions<BitBetEntities> options, ILogger logger) : base(options, logger) { }
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
        public void StartNewGame()
        {
            PlayerManager._playerHand.Clear();
            DealerManager._dealerHand.Clear();
            _deck.Shuffle();
            PlayerManager._playerHand.Add(_deck.Deal());
            PlayerManager._playerHand.Add(_deck.Deal());
            DealerManager._dealerHand.Add(_deck.Deal());
            DealerManager._dealerHand.Add(_deck.Deal());
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
        public GameResult CompleteGame()
        {
            List<Card> dealerHand;
            List<Card> playerHand;
            dealerHand = DealerManager._dealerHand;
            playerHand = PlayerManager._playerHand;
            int dealerValue = CalculateHandValue(dealerHand);
            int BlackjackValue = 21;
            GameResult result;
            int playerValue = CalculateHandValue(playerHand);

            //Player Plays
            //Todo: remove when UI is implemented
            if (dealerValue != BlackjackValue)
            {
                while (playerValue < 17)
                {
                    playerHand.Add(_deck.Deal());
                    playerValue = CalculateHandValue(playerHand);
                }
                if (playerValue == BlackjackValue)
                {
                    result = GameResult.PlayerBlackjack;
                }
                if (playerValue > BlackjackValue)
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
                //Add Muiltiplier for winnings
                result = GameResult.PlayerWins;
            }
            else
            {
                //Dealer Plays
                while (dealerValue < 17)
                {
                    playerHand.Add(_deck.Deal());
                    dealerValue = CalculateHandValue(dealerHand);
                }
                if (dealerValue == BlackjackValue)
                {
                    result = GameResult.DealerWins;
                }
                if (dealerValue > BlackjackValue)
                {
                    result = GameResult.PlayerWins;
                }
                else
                {
                    if (dealerValue > playerValue)
                    {
                        result = GameResult.DealerWins;
                    }
                    else
                    {
                        result = GameResult.PlayerWins;
                    }
                }
            }
            return result;
        }
    }
}
