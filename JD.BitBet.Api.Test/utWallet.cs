using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class utWallet : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Wallet>(6);
        }
        [TestMethod]
        public async Task InsertTestAsync()
        {
            Wallet wallet = new Wallet
            {

                WalletAddress = "Test",
                UserId = Guid.Parse("8cb82cd3-b09f-4680-9580-0224284b0df8"),
                Balance = 1200.00,
            };
            await base.InsertTestAsync<Wallet>(wallet);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Wallet>(new KeyValuePair<string, string>("WalletAddress", "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Wallet>(new KeyValuePair<string, string>("WalletAddress", "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"));
        }

    }
}
