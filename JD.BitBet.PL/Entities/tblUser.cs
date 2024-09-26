﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblUser : IEntity
    {
        public Guid Id { get; set; }
        public string ?Email { get; set; }
        public string ?Password { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<tblErrorLog> ErrorLogs { get; set; }
        public virtual ICollection<tblGame> Games { get; set; }
        public virtual ICollection<tblWallet> Wallets { get; set; }
    }
}
