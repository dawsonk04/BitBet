using JD.BitBet.BL.Models;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL
{
    public class DealerManager
    {
        private Deck _deck;
        private Hand _playerHand;
        private Hand _dealerHand;
        private bool _isPlayerTurn;

        public DealerManager()
        {
            _deck = new Deck();
            _playerHand = new Hand();
            _dealerHand = new Hand();
            _isPlayerTurn = true;
        }

        public void StartGame(double betAmount)
        {
            try
            {
                _deck.Shuffle();
                _playerHand.Clear();
                _dealerHand.Clear();

                _playerHand.BetAmount = betAmount;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DealInitalCards()
        {
            _playerHand.AddCard(_deck.Deal());
            _playerHand.AddCard(_deck.Deal());
            _dealerHand.AddCard(_deck.Deal());
            _dealerHand.AddCard(_deck.Deal());
        }

        public void PlayerAction(PlayerAction action)
        {
            try
            {
                if (!_isPlayerTurn) return;




            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
