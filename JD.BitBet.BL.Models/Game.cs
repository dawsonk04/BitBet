using JD.BitBet.PL;
using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public double GameResult { get; set; }
        public List<User> Users { get; set; }
    }
}
