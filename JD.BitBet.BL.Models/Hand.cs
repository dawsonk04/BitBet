using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class Hand
    {
        public Guid Id { get; set; }
        public double? Result { get; set; }
        public List<Card> Cards { get; set; }
    }
}
