using static JD.BitBet.BL.DealerManager;
using static JD.BitBet.BL.Models.Cards;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utDealerManager
    {
        private Deck _deck;
        private DealerManager _dealerManager;

        [TestInitialize] 
        public void Setup()
        {
            _deck = new Deck();
            _dealerManager = new DealerManager(_deck);
        }
        [TestMethod]
        public void DealerStand ()
        {
            var dealerHand = new List<Card>();
            _dealerManager.StartNewGame();
            dealerHand.Add(new Card(Rank.King, Suit.Hearts));
            dealerHand.Add(new Card(Rank.King, Suit.Spades));
            _dealerManager.setDealerHand(dealerHand);
            Assert.AreEqual(GameResult.DealerStand, _dealerManager.CompleteDealerTurn());
        }
        [TestMethod]
        public void DealerBusts()
        {
            var dealerHand = new List<Card>();
            _dealerManager.StartNewGame();
            dealerHand.Add(new Card(Rank.King, Suit.Hearts));
            dealerHand.Add(new Card(Rank.Six, Suit.Spades));
            dealerHand.Add(new Card(Rank.King, Suit.Spades));
            _dealerManager.setDealerHand(dealerHand);
            Assert.AreEqual(GameResult.DealerBust, _dealerManager.CompleteDealerTurn());
        }
        [TestMethod]
        public void DealerBlackJack()
        {
            var dealerHand = new List<Card>();
            _dealerManager.StartNewGame();
            dealerHand.Add(new Card(Rank.King, Suit.Hearts));
            dealerHand.Add(new Card(Rank.Ace, Suit.Spades));
            dealerHand.Add(new Card(Rank.King, Suit.Spades));
            _dealerManager.setDealerHand(dealerHand);
            Assert.AreEqual(GameResult.DealerBlackJack, _dealerManager.CompleteDealerTurn());
        }
        [TestMethod]
        public void SimulateGame()
        {
            _dealerManager.StartNewGame();
            Assert.IsNotNull(_dealerManager.CompleteDealerTurn());
        }
    }
}
