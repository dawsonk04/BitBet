using JD.BitBet.BL.Models;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class DealerManager
    {
        private readonly Deck _deck;
        private List<Card> _playerHand;
        private List<Card> _dealerHand;
        private double _betAmount;
        private const int BlackjackValue = 21;

        public DealerManager(Deck deck)
        {
            _deck = deck;
            _playerHand = new List<Card>();
            _dealerHand = new List<Card>();
        }

        public void StartNewGame(double betAmount)
        {
            _betAmount = betAmount;
            _playerHand.Clear();
            _dealerHand.Clear();
            _deck.Shuffle();

            // Initial deal
            _playerHand.Add(_deck.Deal());
            _dealerHand.Add(_deck.Deal());
            _playerHand.Add(_deck.Deal());
            _dealerHand.Add(_deck.Deal());
        }

        public bool CanDoubleDown()
        {
            return _playerHand.Count == 2 && CalculateHandValue(_playerHand) >= 9 && CalculateHandValue(_playerHand) <= 11;
        }

        public GameResult PlayerHit()
        {
            _playerHand.Add(_deck.Deal());
            int handValue = CalculateHandValue(_playerHand);

            if (handValue > BlackjackValue)
                return GameResult.PlayerBust;

            if (handValue == BlackjackValue)
                return GameResult.PlayerBlackjack;

            return GameResult.InProgress;
        }

        public GameResult PlayerDoubleDown()
        {
            if (!CanDoubleDown())
                throw new InvalidOperationException("Double down is not allowed in current situation");

            _betAmount *= 2;
            _playerHand.Add(_deck.Deal());

            int handValue = CalculateHandValue(_playerHand);
            if (handValue > BlackjackValue)
                return GameResult.PlayerBust;

            return CompleteDealerTurn();
        }

        public GameResult PlayerStand()
        {
            return CompleteDealerTurn();
        }

        private GameResult CompleteDealerTurn()
        {
            while (CalculateHandValue(_dealerHand) < 17)
            {
                _dealerHand.Add(_deck.Deal());
            }

            int dealerValue = CalculateHandValue(_dealerHand);
            int playerValue = CalculateHandValue(_playerHand);

            if (dealerValue > BlackjackValue)
                return GameResult.DealerBust;

            if (dealerValue > playerValue)
                return GameResult.DealerWins;

            if (playerValue > dealerValue)
                return GameResult.PlayerWins;

            return GameResult.Push;
        }

        public int CalculateHandValue(List<Card> hand)
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (card.Rank == Rank.Ace)
                    aceCount++;
                value += (int)card.Rank;
            }

            while (value > BlackjackValue && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }

        public IReadOnlyList<Card> GetPlayerHand() => _playerHand.AsReadOnly();
        public IReadOnlyList<Card> GetDealerHand() => _dealerHand.AsReadOnly();
        public double GetBetAmount() => _betAmount;
    }

    public enum GameResult
    {
        InProgress,
        PlayerBlackjack,
        PlayerBust,
        DealerBust,
        PlayerWins,
        DealerWins,
        Push
    }
}
