using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL
{
    public partial class tblHand : IEntity
    {
        public Guid Id { get; set; }
        public Double BetAmount { get; set; }
        public Double Result { get; set; }
    }
}
