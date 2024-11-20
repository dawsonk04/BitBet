using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblCard : IEntity
    {
        public Guid Id { get; set; }
        public Guid HandId {  get; set; }
        public int Value { get; set; }  
        public String Suit {  get; set; }
        public tblHand hand {  get; set; }  
    }
}
