using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblUser : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? gameId { get; set; }
        public DateTime CreateDate { get; set; }
        public double? BetAmount { get; set; }
        public bool? HasBet { get; set; }
        public virtual tblGame Game { get; set; }
        public virtual ICollection<tblHand> Hands { get; set; }
        public virtual ICollection<tblErrorLog> ErrorLogs { get; set; }
        public virtual ICollection<tblGame> Games { get; set; }
        public virtual ICollection<tblWallet> Wallets { get; set; }
    }
}
