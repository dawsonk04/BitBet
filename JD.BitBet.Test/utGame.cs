using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL.Test
{
    [TestClass]
    public class utGame : utBase<tblGame>
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
            int rowsAffected = InsertTest(new tblGame
            {
                Id = Guid.NewGuid(),
                UserId = base.LoadTest().FirstOrDefault().UserId,
                GameResult = 20
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGame row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.GameResult = 20;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblGame row = base.LoadTest().FirstOrDefault(x => x.GameResult == 20);
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}

