using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{

    [TestClass]
    public class utTransaction : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Transaction>(6);
        }
    }
}
