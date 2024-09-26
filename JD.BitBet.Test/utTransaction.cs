namespace JD.BitBet.PL.Test
{
    [TestClass]
    public class utTransaction : utBase<tblTransaction>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var Users = base.LoadTest();
            Assert.AreEqual(expected, Users.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblTransaction
            {
                Id = Guid.NewGuid(),
                WalletId = Guid.NewGuid(),
                TransactionType = "Deposit",
                Amount = 10,
                TransactionDate = DateTime.Now,
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblTransaction row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.Amount = 20;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblTransaction row = base.LoadTest().FirstOrDefault(x => x.Amount == 20);
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
