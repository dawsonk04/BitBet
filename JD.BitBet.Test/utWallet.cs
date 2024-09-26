using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL.Test
{
    [TestClass]
    public class utWallet : utBase<tblWallet>
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
            int rowsAffected = InsertTest(new tblWallet
            {
                Id = Guid.NewGuid(),
                WalletAddress = "testingaddress",
                UserId = base.LoadTest().FirstOrDefault().UserId,
                Balance = 0.55,
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblWallet row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.Balance = 20;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblWallet row = base.LoadTest().FirstOrDefault(x => x.Balance == 20);
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
