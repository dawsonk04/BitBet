using JD.BitBet.BL.Models;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace JD.BitBet.UI.Controllers
{
    public class GameController : GenericController<Game>
    {
        private readonly ApiClient _apiClient;
        private GameState state;
        public GameController(HttpClient httpClient) : base(httpClient)
        {
            this._apiClient = new ApiClient(httpClient.BaseAddress.AbsoluteUri);

        }
        public  async Task<IActionResult> GameIndex()
        {
            var response = await _apiClient.GetAsync("Game/state");
            if (response.IsSuccessStatusCode)
            {
                var gameState = await response.Content.ReadAsStringAsync();
                ViewBag.GameState = gameState;
            }
            else
            {
                ViewBag.Error = "Unable to fetch game state.";
            }

            return View();
        }

        //public async Task<IActionResult> Start()
        //{
        //    var response = await _apiClient.PostAsync("Game/start", null);
        //    HttpContext.Session.SetString("GameState", JsonConvert.SerializeObject(response));
        //    ViewBag.GameState = HttpContext.Session.GetString("GameState");
        //    return RedirectToAction("GameIndex");
        //}

        //public async Task<IActionResult> Hit()
        //{
        //    //var response = await _apiClient.PostAsync("Game/hit", null);
        //    //return RedirectToAction("GameIndex");
        //    var gameStateJson = HttpContext.Session.GetString("GameState");
        //    if (string.IsNullOrEmpty(gameStateJson))
        //    {
        //        return RedirectToAction("GameIndex");
        //    }

        //    var gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson);

        //    var content = new StringContent(JsonConvert.SerializeObject(gameState), Encoding.UTF8, "application/json");
        //    var response = await _apiClient.PostAsync("Game/hit", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var updatedGameStateJson = await response.Content.ReadAsStringAsync();
        //        HttpContext.Session.SetString("GameState", updatedGameStateJson);
        //    }

        //    return RedirectToAction("GameIndex");
        //}
        public async Task<IActionResult> Start()
        {
            var response = await _apiClient.PostAsync("Game/start", null);
            var gameStateJson = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("GameState", gameStateJson);
                var gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson);
                return View("GameIndex", gameState);
            }
            else
            {
                ViewBag.Error = "Failed to start the game.";
            }

            return View("GameIndex");
        }
        public async Task<IActionResult> Hit()
        {
            var gameStateJson = HttpContext.Session.GetString("GameState");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }

            var gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameState), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync("Game/hit", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("GameState", updatedGameStateJson);
                gameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);
            }
            else
            {
                ViewBag.Error = "Failed to perform hit action.";
            }

            return View("GameIndex", gameState);
        }
        public async Task<IActionResult> Stand()
        {
            var response = await _apiClient.PostAsync("Game/stand", null);
            return RedirectToAction("GameIndex");
        }

        public void Double()
        {

        }

        public void Split()
        {

        }

    }
}
