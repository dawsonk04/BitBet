using JD.BitBet.PL;
using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double GameResult { get; set; }
        public virtual tblUser User { get; set; }
    }
}
