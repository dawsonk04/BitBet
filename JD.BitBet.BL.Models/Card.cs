
using static JD.BitBet.PL.Entities.tblCard;

namespace JD.BitBet.BL.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public Guid HandId { get; set; }
        public Rank rank { get; private set; }
        public Suit suit { get; private set; }
        public Card(Rank rank2, Suit suit2)
        {
            rank = rank2;
            suit = suit2;
        }

        public override string ToString()
        {
            return $"{rank} of {suit}";
        }
    }

}

