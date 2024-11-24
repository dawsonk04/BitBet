using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.PL.Entities
{
    public class tblGameState : IEntity
    {
        public Guid Id { get; set; }
        public Guid dealerHandId {  get; set; }
        public Guid playerHandId { get; set; }
        public int playerHandVal { get; set; }
        public int dealerHandVal { get; set; }
        public bool isPlayerTurn { get; set; }
        public bool isGameOver { get; set; }
        public virtual tblHand dealerHand { get; set; }
        public virtual tblHand playerHand { get; set; }
    }
}
