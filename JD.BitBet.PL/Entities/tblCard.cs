using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public partial class tblCard : IEntity
    {
        public Guid Id { get; set; }
        public Guid HandId {  get; set; }
        public int Rank { get; set; }  
        public String Suit {  get; set; }
        public virtual tblHand hand {  get; set; }  
    }
}
