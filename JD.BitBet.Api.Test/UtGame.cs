using JD.BitBet.BL.Models;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class UtGame : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Game>(6);
        }
        [TestMethod]
        public async Task InsertTestAsync()
        {
            Game game = new Game
            {
                UserId = Guid.Parse("8cb82cd3-b09f-4680-9580-0224284b0df8"),
                GameResult = -200,
            };
            await base.InsertTestAsync<Game>(game);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Game>(new KeyValuePair<string, string>("Id", "3bb9209d-5f39-41ed-ba67-9dc14305126b"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Game>(new KeyValuePair<string, string>("Id", "3bb9209d-5f39-41ed-ba67-9dc14305126b"));
        }

    }
}
