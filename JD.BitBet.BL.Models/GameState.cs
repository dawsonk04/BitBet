﻿    using JD.BitBet.PL;

namespace JD.BitBet.BL.Models
{
    public class GameState
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public Hand playerHand { get; set; }
        public Hand dealerHand { get; set; }
        public int playerHandVal { get; set; }
        public int dealerHandVal { get; set; }
        public Guid playerHandId { get; set; }
        public Guid dealerHandId { get; set; }
        public bool isPlayerTurn { get; set; }
        public bool isGameOver { get; set; }
        public double? BetAmount { get; set; }
        public string message { get; set; }
    }
}
