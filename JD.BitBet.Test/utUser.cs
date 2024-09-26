using JD.BitBet.PL.Entities;

namespace JD.BitBet.PL.Test
{
    public class utUser
    {
        [TestClass]
        public class utUser : utBase<tblUser>
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
                int rowsAffected = InsertTest(new tblUser
                {
                    Id = Guid.NewGuid(),
                    Email = "john@gmail.com",
                    Password = "password",
                    CreateDate = DateTime.Now

                });

                Assert.AreEqual(1, rowsAffected);
            }

            [TestMethod]
            public void UpdateTest()
            {
                tblUser row = base.LoadTest().FirstOrDefault();
                if (row != null)
                {
                    row.Email = "dawson@gmail.com";
                    row.Password = "test123";
                    int rowsAffected = UpdateTest(row);
                    Assert.AreEqual(1, rowsAffected);
                }
            }


            [TestMethod]
            public void DeleteTest()
            {
                tblUser row = base.LoadTest().FirstOrDefault(x => x.Email == "Other");
                if (row != null)
                {
                    int rowsAffected = DeleteTest(row);
                    Assert.IsTrue(rowsAffected == 1);
                }

            }
        }
    }

}

