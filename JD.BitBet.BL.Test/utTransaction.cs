using JD.BitBet.BL.Models;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utTransaction : utBase
    {
        [TestMethod]
        public async Task LoadTest()
        {
            List<Transaction> transactions = await new TransactionManager(options).LoadAsync();
            int expected = 4;
            Assert.AreEqual(expected, transactions.Count);
        }

        [TestMethod]

        public async Task InsertTest()
        {
            Transaction transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                TransactionDate = DateTime.Now,
                TransactionType = "test",
                Amount = 120,
                WalletId = (await new WalletManager(options).LoadAsync()).FirstOrDefault().Id
            };
            Guid result = await new TransactionManager(options).InsertAsync(transaction, true);
            Assert.AreNotEqual(result, Guid.Empty);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            Transaction transaction = (await new TransactionManager(options).LoadAsync()).FirstOrDefault();
            transaction.TransactionDate = DateTime.Now;
            Assert.IsTrue(new TransactionManager(options).UpdateAsync(transaction, true).Result > 0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Transaction transaction = (await new TransactionManager(options).LoadAsync()).FirstOrDefault();
            Assert.IsTrue(new TransactionManager(options).DeleteAsync(transaction.Id, true).Result > 0);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            Transaction transaction = (await new TransactionManager(options).LoadAsync()).FirstOrDefault();
            Assert.AreEqual((await new TransactionManager(options).LoadByIdAsync(transaction.Id)).Id, transaction.Id);
        }


    }
}