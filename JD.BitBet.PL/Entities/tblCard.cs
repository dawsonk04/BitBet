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
        public Guid HandId { get; set; }
        public Rank rank { get; set; }
        public Suit suit { get; set; }
        public virtual tblHand hand { get; set; }
        public enum Rank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 10,
            Queen = 10,
            King = 10,
            Ace = 11
        }

        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
    }
}
