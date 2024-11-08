using JD.BitBet.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class DealerManager
    {
        private List<Card> _dealerHand;
        private Card card;
        private Deck _deck;
        private const int BlackjackValue = 21;
        public IReadOnlyList<Card> GetDealerHand() => _dealerHand.AsReadOnly();

        public DealerManager(Deck deck)
        {
            _deck = deck;
            _dealerHand = new List<Card>();
        }
        public void StartNewGame()
        {
            _dealerHand.Clear();
            _deck.Shuffle();
            _dealerHand.Add(_deck.Deal());
            _dealerHand.Add(_deck.Deal());
        }
        public void setDealerHand(List<Card> hand)
        {
            _dealerHand = hand;
        }
        public GameManager.GameResult CompleteDealerTurn()
        {
            while (GameManager.CalculateHandValue(_dealerHand) < 17)
            {
                _dealerHand.Add(_deck.Deal());
            }

            int dealerValue = GameManager.CalculateHandValue(_dealerHand);

            if (dealerValue == BlackjackValue)
                return GameManager.GameResult.DealerBlackJack;
            if (dealerValue > BlackjackValue)
                return GameManager.GameResult.DealerBust;
            else
                return GameManager.GameResult.DealerStand;
        }
    }
}
