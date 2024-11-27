using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL
{
    public partial class tblHand : IEntity
    {
        public Guid Id { get; set; }
        public double BetAmount { get; set; }
        public double Result { get; set; }
        public Guid UserId {  get; set; }
        public virtual tblUser user { get; set; }
        public virtual ICollection<tblCard> cards { get; set; }
    }
}
