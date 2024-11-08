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
        public static List<Card> _dealerHand;
        private Card card;
        public IReadOnlyList<Card> GetDealerHand() => _dealerHand.AsReadOnly();

        public DealerManager()
        {
            _dealerHand = new List<Card>();
        }
        public void setDealerHand(List<Card> hand)
        {
            _dealerHand = hand;
        }
    }
}
