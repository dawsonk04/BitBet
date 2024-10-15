using Microsoft.Extensions.Options;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utWallet : utBase
    {
        [TestMethod]
        public async Task LoadTest()
        {
            List<Wallet> wallets = await new WalletManager(options).LoadAsync();
            int expected = 2;
            Assert.AreEqual(expected, wallets.Count);
        }

        [TestMethod]

        public async Task InsertTest()
        {
            Wallet wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Balance = 2000,
                WalletAddress = "Test"
            };
            Guid result = await new WalletManager(options).InsertAsync(wallet, true);
            Assert.AreNotEqual(result, Guid.Empty);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            Wallet wallet = (await new WalletManager(options).LoadAsync()).FirstOrDefault();
            wallet.Balance = 1120;
            Assert.IsTrue(new WalletManager(options).UpdateAsync(wallet, true).Result > 0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Wallet wallet = (await new WalletManager(options).LoadAsync()).FirstOrDefault();
            Assert.IsTrue(new WalletManager(options).DeleteAsync(wallet.Id, true).Result > 0);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            Wallet wallet = (await new WalletManager(options).LoadAsync()).FirstOrDefault();
            Assert.AreEqual((await new WalletManager(options).LoadByIdAsync(wallet.Id)).Id, wallet.Id);
        }


    }
}