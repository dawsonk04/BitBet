using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class utHand : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Hand>(6);
        }
        [TestMethod]

        public async Task InsertTestAsync()
        {
            Hand hand = new Hand
            {
                GameId = Guid.Parse("3bb9209d-5f39-41ed-ba67-9dc14305126b"),
                BetAmount = 1,
                Result = -1,
            };
            await base.InsertTestAsync<Hand>(hand);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Hand>(new KeyValuePair<string, string>("Id", "59645000-6cc0-436e-80e5-b69a08b599e9"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Hand>(new KeyValuePair<string, string>("Id", "59645000-6cc0-436e-80e5-b69a08b599e9"));
        }

    }
}
