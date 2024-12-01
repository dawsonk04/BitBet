using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblGameState : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public Guid dealerHandId { get; set; }
        public Guid playerHandId { get; set; }
        public int playerHandVal { get; set; }
        public int dealerHandVal { get; set; }
        public bool isPlayerTurn { get; set; }
        public bool isGameOver { get; set; }
        public string message { get; set; }
        public virtual tblUser User { get; set; }
        public virtual tblGame game { get; set;}
        public virtual tblHand dealerHand { get; set; }
        public virtual tblHand playerHand { get; set; }
    }
}
