using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblWallet
    {
        public Guid Id { get; set; }   
        public string ?WalletAddress { get; set; }
        public Guid UserId { get; set; }
        public double Balance { get; set; }
    }
}
