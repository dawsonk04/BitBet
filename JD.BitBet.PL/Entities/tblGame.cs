using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblGame : IEntity
    {
        public Guid Id { get; set; }
        public double GameResult { get; set; }
        public virtual List<tblUser> Users { get; set; }
        public virtual ICollection<tblGameState> GameStates { get; set; }
    }
}
