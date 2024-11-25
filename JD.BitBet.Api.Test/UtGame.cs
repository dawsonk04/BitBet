using JD.BitBet.BL.Models;
using Newtonsoft.Json;
using System.Text;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class UtGame : utBase
    {
        public HttpClient _client;
        UtGame()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("");
        }
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
            await base.DeleteTestAsync<Game>(new KeyValuePair<string, string>("Id", "f0819c2c-acfc-4d79-9a25-2cf588fd565e"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Game>(new KeyValuePair<string, string>("Id", "f0819c2c-acfc-4d79-9a25-2cf588fd565e"));
        }
        [TestMethod]
        public async Task Hit()
        {
            _client = new HttpClient();
            var response = await _client.PostAsync("/Game/start", null); 
            response.EnsureSuccessStatusCode();
            var startGameResult = await response.Content.ReadAsStringAsync();
            var returnedGameState = JsonConvert.DeserializeObject<GameState>(startGameResult);

            Assert.IsNotNull(returnedGameState);
            Assert.IsNotNull(returnedGameState.playerHand);
            Assert.IsNotNull(returnedGameState.dealerHand);

            var hitContent = new StringContent(JsonConvert.SerializeObject(returnedGameState), Encoding.UTF8, "application/json");
            var hitResponse = await _client.PostAsync("/Game/hit", hitContent);

            hitResponse.EnsureSuccessStatusCode();
            var hitResult = await hitResponse.Content.ReadAsStringAsync();
            var updatedGameState = JsonConvert.DeserializeObject<GameState>(hitResult);

            Assert.AreEqual(returnedGameState.playerHand.Cards.Count + 1, updatedGameState.playerHand.Cards.Count);
        }
    }
}
