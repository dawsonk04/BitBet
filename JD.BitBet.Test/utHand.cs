namespace JD.BitBet.PL.Test
{
    [TestClass]
    public class utHand : utBase<tblHand>
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
            int rowsAffected = InsertTest(new tblHand
            {
                Id = Guid.NewGuid(),
                BetAmount = 1,
                Result = 20,
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblHand row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.Result = 20;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblHand row = base.LoadTest().FirstOrDefault(x => x.Result == 20);
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
