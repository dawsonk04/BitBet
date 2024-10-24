using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utComputerPlayer
    {
        private Deck _deck;
        private DealerManager _dealerManager;
        private ComputerPlayer _computerPlayer;

        [TestInitialize]
        public void Setup()
        {
            _deck = new Deck();
            _dealerManager = new DealerManager(_deck);
            _computerPlayer = new ComputerPlayer(_dealerManager);
        }

        [TestMethod]
        public void PlayHand_CompletesGame()
        {
            // Arrange
            _dealerManager.StartNewGame(100);

            // Act
            var result = _computerPlayer.PlayHand();

            // Assert
            Assert.AreNotEqual(GameResult.InProgress, result);
        }

        [TestMethod]
        public void PlayHand_StopsAt17OrHigher()
        {
            // Arrange
            _dealerManager.StartNewGame(100);

            // Act
            _computerPlayer.PlayHand();
            var finalHandValue = _dealerManager.CalculateHandValue(_dealerManager.GetPlayerHand().ToList());

            // Assert
            Assert.IsTrue(finalHandValue >= 17 || finalHandValue == 0,
                $"Hand value {finalHandValue} should be >= 17 or 0 (bust)");
        }

        [TestMethod]
        public void PlayHand_WithBustHand_ReturnsPlayerBust()
        {
            // Arrange
            _dealerManager.StartNewGame(100);
            var playerHand = _dealerManager.GetPlayerHand().ToList();
            playerHand.Clear();
            playerHand.Add(new Card(Rank.King, Suit.Hearts));
            playerHand.Add(new Card(Rank.Queen, Suit.Spades));
            playerHand.Add(new Card(Rank.Jack, Suit.Diamonds));

            // Act
            var result = _computerPlayer.PlayHand();

            // Assert
            Assert.AreEqual(GameResult.PlayerBust, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DoubleDown_WhenNotAllowed_ThrowsException()
        {
            // Arrange
            _dealerManager.StartNewGame(100);
            var playerHand = _dealerManager.GetPlayerHand().ToList();
            playerHand.Clear();
            playerHand.Add(new Card(Rank.King, Suit.Hearts));
            playerHand.Add(new Card(Rank.Queen, Suit.Spades));

            // Act & Assert
            _dealerManager.PlayerDoubleDown();
        }
    }
}
