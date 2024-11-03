using JD.Utility;
using Microsoft.Extensions.Options;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public async Task ExportDataTest()
        {
            var entities = await new UserManager(options).LoadAsync().ConfigureAwait(false);
            string[] columns = { "Email", "CreateDate" };
            var data = UserManager.ConvertData(entities, columns);
            Excel.Export("user.xlsx", data);
        }

        [TestInitialize]
        public async Task Initialize()
        {
            await new UserManager(options).Seed();
            transaction = dc.Database.BeginTransaction();
        }


        [TestMethod]
        public async Task LoadTest()
        {
            var users = await new UserManager(options).LoadAsync();
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public async Task InsertTest()
        {
            User user = new User { Email = "jstrange2@gmail.com", Password = "password", CreateDate = DateTime.Now};
            Guid result = await new UserManager(options).InsertAsync(user, true);
            Assert.AreNotEqual(result, Guid.Empty);
        }

        [TestMethod]
        public async Task LoginSuccess()
        {
            User user = new User { Email = "jbstrange2@gmail.com", Password = "password", };
            bool result = await new UserManager(options).LoginAsync(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task LoginFailAsync()
        {
            try
            {
                User user = new User { Email = "jbstrange2@gmail.com", Password = "xxzxx", CreateDate = DateTime.Now };
                bool result = await new UserManager(options).LoginAsync(user);
                Assert.IsFalse(result);
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }



    }
}
