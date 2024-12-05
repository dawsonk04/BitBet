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
        public async Task<IActionResult> GameIndex()
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
        public async Task<IActionResult> GameList()
        {
            var response = await _apiClient.GetAsync("Game/");

            if (response.IsSuccessStatusCode)
            {
                var gamesJson = await response.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<Game>>(gamesJson);
                return View("GameList", games);
            }
            else
            {
                ViewBag.Error = "Unable to fetch games.";
                return View();
            }
        }
        public async Task<IActionResult> JoinGame(Guid gameId)
        {
            try
            {
                var userId = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }
                var response = await _apiClient.PostAsync($"Game/join/{gameId}/{userId}", null);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GameIndex", new { gameId });
                }
                else
                {
                    ViewBag.Error = "Unable to join the game.";
                    return RedirectToAction("GameList", "Game");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        public async Task<IActionResult> Start()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "User");
            }
            var jsonContent = JsonConvert.SerializeObject(new { UserId = userId });
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync("Game/start", httpContent);
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
        public async Task<IActionResult> Double()
        {
            var gameStateJson = HttpContext.Session.GetString("GameState");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }

            var gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameState), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync("Game/double", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("GameState", updatedGameStateJson);
                gameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);
            }
            else
            {
                ViewBag.Error = "Failed to perform double action.";
            }

            return View("GameIndex", gameState);
        }
        public async Task<IActionResult> Stand()
        {
            var gameStateJson = HttpContext.Session.GetString("GameState");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }

            var gameState = JsonConvert.DeserializeObject<GameState>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameState), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync("Game/stand", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("GameState", updatedGameStateJson);
                gameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);
            }
            else
            {
                ViewBag.Error = "Failed to perform stand action.";
            }

            return View("GameIndex", gameState);
        }

    }
}
