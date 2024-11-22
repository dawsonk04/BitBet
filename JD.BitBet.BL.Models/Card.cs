using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL.Models
{
    public class Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public Guid handId { get; set; }
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

}

