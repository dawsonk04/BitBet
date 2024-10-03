using JD.BitBet.PL;
using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public string? WalletAddress { get; set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<tblTransaction> Transactions { get; set; }
        public virtual tblUser User { get; set; }
    }
}
