namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utSimulateGame
    {
        [TestMethod] 
        public void PlayerBlackJack()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Ace, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Seven, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.PlayerWins, result);
        }
        [TestMethod]
        public void DealerBlackJack()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.King, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Ace, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.DealerWins, result);
        }
        [TestMethod]
        public void BothPlayerBlackJackPush()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Ace, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Ace, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.Push, result);
        }
        [TestMethod]
        public void HandSameValue()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Eight, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Eight, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.Push, result);
        }
        [TestMethod]
        public void DealerWins()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Seven, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Nine, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.DealerWins, result);
        }
        [TestMethod]
        public void PlayerWins()
        {
            GameManager.GameResult result = GameManager.GameResult.InProgress;
            List<Card> PlayerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Eight, Cards.Suit.Diamonds)
            };
            List<Card> DealerHand = new List<Card>
            {
                new Card(Cards.Rank.King, Cards.Suit.Clubs),
                new Card(Cards.Rank.Seven, Cards.Suit.Diamonds)
            };
            GameManager._playerHand = PlayerHand;
            GameManager._dealerHand = DealerHand;
            result = GameManager.CompleteGame();
            Assert.AreEqual(GameManager.GameResult.PlayerWins, result);
        }
        [TestMethod]
        public void SimulateGame()
        {
            GameManager.StartNewGame();
            GameManager.GameResult result = GameManager.CompleteGame();
            Assert.IsNotNull(result);
        }
    }
}
