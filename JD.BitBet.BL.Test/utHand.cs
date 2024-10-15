using Microsoft.Extensions.Options;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utHand : utBase
    {
        [TestMethod]
        public async Task LoadTest()
        {
            List<Hand> hands = await new HandManager(options).LoadAsync();
            int expected = 2;
            Assert.AreEqual(expected, hands.Count);
        }

        [TestMethod]

        public async Task InsertTest()
        {
            Hand hand = new Hand
            {
                Id = Guid.NewGuid(),
                BetAmount = 200,
                GameId = (await new HandManager(options).LoadAsync()).FirstOrDefault().GameId,
                Result = 2012
            };
            Guid result = await new HandManager(options).InsertAsync(hand, true);
            Assert.AreNotEqual(result, Guid.Empty);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            Hand hand = (await new HandManager(options).LoadAsync()).FirstOrDefault();
            hand.Result = -243;
            Assert.IsTrue(new HandManager(options).UpdateAsync(hand, true).Result > 0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Hand hand = (await new HandManager(options).LoadAsync()).FirstOrDefault();
            Assert.IsTrue(new HandManager(options).DeleteAsync(hand.Id, true).Result > 0);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            Hand hand = (await new HandManager(options).LoadAsync()).FirstOrDefault();
            Assert.AreEqual((await new HandManager(options).LoadByIdAsync(hand.Id)).Id, hand.Id);
        }


    }
}