using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class Hand
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public double BetAmount { get; set; }
        public double Result { get; set; }
        public virtual tblGame Game { get; set; }

        private List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }
        public void Clear()
        {
            _cards.Clear();
        }
        public int GetHandValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (Card card in _cards)
            {
                value += card.GetValue();
                if (card.IsAce())
                {
                    aceCount++;
                }
            }

            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }
            return value;
        }

        public bool IsBusted()
        {
            return GetHandValue() > 21;
        }

    }
}
