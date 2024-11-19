using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<User>(5);
        }
        [TestMethod]

        public async Task InsertTestAsync()
        {
            User user = new User
            {
                Email = "Test",
                Password = "Test",
                CreateDate = DateTime.Now,
            };
            await base.InsertTestAsync<User>(user);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<User>(new KeyValuePair<string, string>("Email", "jbstrange2@gmail.com"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<User>(new KeyValuePair<string, string>("Email", "jbstrange2@gmail.com"));
        }

    }
}
