using JD.BitBet.PL;

namespace JD.BitBet.BL.Models
{
    public class GameState
    {
        public List<Card> playerHand { get; set; }
        public List<Card> dealerHand { get; set; }
        public List<List<Card>> playerHands { get; set; }
        public int playerHandVal { get; set; }
        public int dealerHandVal { get; set; }
        public Guid playerHandId { get; set; }
        public Guid dealerHandId { get; set; }
        public bool isPlayerTurn { get; set; }
        public bool isGameOver { get; set; }
        public string Message { get; set; }
        public GameState()
        {
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            playerHands = new List<List<Card>>();
            isPlayerTurn = true;
            isGameOver = false;
            Message = "Game initialized.";
        }

    }
}
