namespace JD.BitBet.BL.Models
{
    public class GameState
    {
        public List<Card> playerHand { get; set; }
        public List<Card> dealerHand { get; set; }
        public List<List<Card>> playerHands { get; set; }
        public int playerHandVal { get; set; }
        public int dealerHandVal { get; set; }
        public bool isPlayerTurn { get; set; }
        public bool isGameOver { get; set; }
        public string Message { get; set; }
    }
}
