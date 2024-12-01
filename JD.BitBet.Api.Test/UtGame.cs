using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.Utility;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace JD.BitBet.Api.Test
{
    [TestClass]
    public class UtGame : utBase
    {
        public ApiClient apiClient;
        UtGame(HttpClient client)
        {
            this.apiClient = new ApiClient(client.BaseAddress.AbsoluteUri);
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
                GameResult = -200,
            };
            await base.InsertTestAsync<Game>(game);

        }
        [TestMethod]
        public async Task JoinStartGame()
        {
            UserManager userManager = new UserManager();
            GameManager gameManager= new GameManager();
            Game game = (await gameManager.LoadAsync()).FirstOrDefault();
            User user = (await userManager.LoadAsync()).FirstOrDefault();
            var response = await apiClient.GetAsync($"/Game/join/{game.Id}/{user.Id}");
            Assert.IsNotNull(response);
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
            var response = await apiClient.PostAsync("/Game/start", null); 
            response.EnsureSuccessStatusCode();
            var startGameResult = await response.Content.ReadAsStringAsync();
            var returnedGameState = JsonConvert.DeserializeObject<GameState>(startGameResult);

            Assert.IsNotNull(returnedGameState);
            Assert.IsNotNull(returnedGameState.playerHand);
            Assert.IsNotNull(returnedGameState.dealerHand);

            var hitContent = new StringContent(JsonConvert.SerializeObject(returnedGameState), Encoding.UTF8, "application/json");
            var hitResponse = await apiClient.PostAsync("/Game/hit", hitContent);

            hitResponse.EnsureSuccessStatusCode();
            var hitResult = await hitResponse.Content.ReadAsStringAsync();
            var updatedGameState = JsonConvert.DeserializeObject<GameState>(hitResult);

            Assert.AreEqual(returnedGameState.playerHand.Cards.Count + 1, updatedGameState.playerHand.Cards.Count);
        }
    }
}
