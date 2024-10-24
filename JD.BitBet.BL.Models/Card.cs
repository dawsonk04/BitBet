using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL.Models
{
    public class Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetValue()
        {
            return (int)Rank;
        }

        public bool IsAce()
        {
            return Rank == Rank.Ace;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

}

