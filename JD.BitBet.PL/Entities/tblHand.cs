using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL
{
    public partial class tblHand : IEntity
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public double BetAmount { get; set; }
        public double Result { get; set; }
        public virtual tblGameState GameState { get; set; }
        public virtual ICollection<tblCard> cards { get; set; }
        public virtual ICollection<tblGameState> dealerGameStates{ get; set; }
        public virtual ICollection<tblGameState> playerGameStates { get; set; }

    }
}
