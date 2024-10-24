using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utDealerManager
    {
        private Deck _deck;
        private DealerManager _dealerManager;

        [TestInitialize] // Use [SetUp] for NUnit
        public void Setup()
        {
            _deck = new Deck();
            _dealerManager = new DealerManager(_deck);
        }

        [TestMethod] // Use [Test] for NUnit
        public void StartNewGame_DealsFourCards()
        {
            // Arrange
            double betAmount = 100;

            // Act
            _dealerManager.StartNewGame(betAmount);

            // Assert
            Assert.AreEqual(2, _dealerManager.GetPlayerHand().Count);
            Assert.AreEqual(2, _dealerManager.GetDealerHand().Count);
        }

        [TestMethod]
        public void PlayerHit_WhenOver21_ReturnsBust()
        {
            // Arrange
            _dealerManager.StartNewGame(100);
            var playerHand = _dealerManager.GetPlayerHand().ToList();
            playerHand.Clear();
            playerHand.Add(new Card(Rank.King, Suit.Hearts));
            playerHand.Add(new Card(Rank.Queen, Suit.Spades));
            playerHand.Add(new Card(Rank.Jack, Suit.Diamonds));

            // Act
            var result = _dealerManager.PlayerHit();

            // Assert
            Assert.AreEqual(GameResult.PlayerBust, result);
        }

        [TestMethod]
        public void CanDoubleDown_WithInitialHandValueOf11_ReturnsTrue()
        {
            // Arrange
            _dealerManager.StartNewGame(100);
            var playerHand = _dealerManager.GetPlayerHand().ToList();
            playerHand.Clear();
            playerHand.Add(new Card(Rank.Six, Suit.Hearts));
            playerHand.Add(new Card(Rank.Five, Suit.Spades));

            // Act
            var canDouble = _dealerManager.CanDoubleDown();

            // Assert
            Assert.IsTrue(canDouble);
        }

        [TestMethod]
        public void CalculateHandValue_WithAceAndKing_Returns21()
        {
            // Arrange
            var hand = new List<Card>
        {
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.King, Suit.Spades)
        };

            // Act
            var result = _dealerManager.CalculateHandValue(hand);

            // Assert
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void CalculateHandValue_WithTwoAces_Returns12()
        {
            // Arrange
            var hand = new List<Card>
        {
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Ace, Suit.Spades)
        };

            // Act
            var result = _dealerManager.CalculateHandValue(hand);

            // Assert
            Assert.AreEqual(12, result);
        }
    }
}
