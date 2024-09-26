namespace JD.BitBet.PL.Test
{
    [TestClass]
    public class utErrorLog : utBase<tblErrorLog>
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
            int rowsAffected = InsertTest(new tblErrorLog
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ErrorType = "error",
                ErrorMessage = "error",
                ErrorDateTime = DateTime.Now
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblErrorLog row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.ErrorMessage = "another error";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblErrorLog row = base.LoadTest().FirstOrDefault(x => x.ErrorMessage == "Other");
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}

