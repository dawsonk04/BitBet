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
        public List<Cards> Cards { get; set; }
    }
}
