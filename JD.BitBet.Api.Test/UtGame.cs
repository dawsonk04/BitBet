using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class UtGame : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Game>(6);
        }
        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Game>(new KeyValuePair<string, string>("Type", "Other"));
        }
    }
}
