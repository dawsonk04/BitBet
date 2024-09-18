using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblUser
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public string ?Email { get; set; }
        public string ?Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
