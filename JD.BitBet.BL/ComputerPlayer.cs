namespace JD.BitBet.BL
{
    public class ComputerPlayer
    {
        private readonly DealerManager _dealerManager;

        public ComputerPlayer(DealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }

        public GameResult PlayHand()
        {
            var playerHand = _dealerManager.GetPlayerHand();
            var handValue = _dealerManager.CalculateHandValue(playerHand.ToList());

            // Basic strategy implementation
            while (handValue < 17)
            {
                var result = _dealerManager.PlayerHit();
                if (result != GameResult.InProgress)
                    return result;

                playerHand = _dealerManager.GetPlayerHand();
                handValue = _dealerManager.CalculateHandValue(playerHand.ToList());
            }

            return _dealerManager.PlayerStand();
        }
    }
}
