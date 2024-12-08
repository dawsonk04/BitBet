using JD.BitBet.PL;
using JD.BitBet.PL.Entities;

namespace JD.BitBet.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? gameId { get; set; }
        public DateTime CreateDate { get; set; }
        public double? betAmount { get; set; }
        public virtual tblGame game {  get; set; } 
        public virtual ICollection<tblErrorLog> ErrorLogs { get; set; }
        public virtual ICollection<tblGame> Games { get; set; }
        public virtual ICollection<tblWallet> Wallets { get; set; }
    }
}
