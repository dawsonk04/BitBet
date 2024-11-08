using JD.BitBet.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.BL
{
    public class PlayerManager
    {
        private List<Card> _playerHand;
        private Card card;
        private Deck _deck;
        private const int BlackjackValue = 21;
        public IReadOnlyList<Card> GetDealerHand() => _playerHand.AsReadOnly();

        public PlayerManager(Deck deck)
        {
            _deck = deck;
            _playerHand = new List<Card>();
        }
        public void StartNewGame()
        {
            _playerHand.Clear();
            _deck.Shuffle();
            _playerHand.Add(_deck.Deal());
            _playerHand.Add(_deck.Deal());
        }
        public void setPlayerHand(List<Card> hand)
        {
            _playerHand = hand;
        }
        public GameManager.GameResult CompletePlayerTurn ()
        {
            //Todo: Remove After UI has been implemented
            while (GameManager.CalculateHandValue(_playerHand) < 17)
            {
                _playerHand.Add(_deck.Deal());
            }

            int playerValue = GameManager.CalculateHandValue(_playerHand);

            if (playerValue == BlackjackValue)
                return GameManager.GameResult.PlayerBlackjack;
            if (playerValue > BlackjackValue)
                return GameManager.GameResult.PlayerBust;
            else
                return GameManager.GameResult.PlayerStand;
        }
    }
}
