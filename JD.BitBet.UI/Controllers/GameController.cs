using Humanizer;
using JD.BitBet.BL.Models;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Filters;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        //public async Task<IActionResult> JoinGame(Guid gameId)
        //{
        //    try
        //    {
        //        var userId = HttpContext.Session.GetString("UserId");
        //        if (string.IsNullOrEmpty(userId))
        //        {
        //            return RedirectToAction("Login", "Account");
        //        }
        //        var response = await _apiClient.PostAsync($"Game/join/{gameId}/{userId}", null);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            HttpContext.Session.SetString("CurrentGameId", gameId.ToString());
        //            return RedirectToAction("GameIndex", new { gameId });
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Unable to join the game.";
        //            return RedirectToAction("GameList", "Game");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        public async Task<IActionResult> JoinGame(Guid gameId)
        {
            try
            {
                var userId = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var loadStateResponse = await _apiClient.GetAsync($"Game/loadstate/{gameId}");

                if (loadStateResponse.IsSuccessStatusCode)
                {
                    var responseData = await loadStateResponse.Content.ReadAsStringAsync();
                    var gameStates = JsonConvert.DeserializeObject<List<GameState>>(responseData);

                    if (gameStates == null || !gameStates.Any())
                    {
                        var joinResponse = await _apiClient.PostAsync($"Game/join/{gameId}/{userId}", null);
                        if (joinResponse.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "You have successfully joined the game!";
                            return View("GameIndex", gameStates);
                        }
                        else
                        {
                            ViewBag.Error = "Unable to join the game.";
                            return RedirectToAction("GameList", "Game");
                        }
                    }
                    else
                    {
                        if (!gameStates.Any(gs => gs.UserId.ToString() == userId))
                        {
                            var joinResponse = await _apiClient.PostAsync($"Game/join/{gameId}/{userId}", null);
                            if (!joinResponse.IsSuccessStatusCode)
                            {
                                ViewBag.Error = "Unable to join the game.";
                                return RedirectToAction("GameList", "Game");
                            }
                        }

                        return View("GameIndex", gameStates);
                    }
                }
                else
                {
                    ViewBag.Error = "Unable to load game states.";
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
            ViewBag.UserId = userId;
            var gameId = HttpContext.Session.GetString("CurrentGameId");

            var response = await _apiClient.PostAsync($"Game/start/{gameId}", null);
            var gameStateJson = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("GameState", gameStateJson);
                var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
                return View("GameIndex", gameStates);
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

            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameStates), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync("Game/hit", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("GameState", updatedGameStateJson);
                gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            }
            else
            {
                ViewBag.Error = "Failed to perform hit action.";
            }

            return View("GameIndex", gameStates);
        }
        public async Task<IActionResult> Double()
        {
            var gameStateJson = HttpContext.Session.GetString("GameState");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }

            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameStates), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync("Game/double", content);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("GameState", updatedGameStateJson);
                gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            }
            else
            {
                ViewBag.Error = "Failed to perform double action.";
            }

            return View("GameIndex", gameStates);
        }
        //public async Task<IActionResult> Stand()
        //{
        //    var gameStateJson = HttpContext.Session.GetString("GameState");
        //    if (string.IsNullOrEmpty(gameStateJson))
        //    {
        //        return RedirectToAction("GameIndex");
        //    }

        //    var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);

        //    var userId = HttpContext.Session.GetString("UserId");

        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return RedirectToAction("Login", "User");
        //    }

        //    var response = await _apiClient.PostAsync($"Game/stand/{userId}", null);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var updatedGameStateJson = await response.Content.ReadAsStringAsync();
        //        HttpContext.Session.SetString("GameState", updatedGameStateJson);
        //        gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Failed to perform stand action.";
        //    }

        //    return View("GameIndex", gameStates);
        //}


        public async Task<IActionResult> Stand()
        {
            // Retrieve the list of game states from the session
            var gameStateJson = HttpContext.Session.GetString("GameState");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }

            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);

            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "User");
            }

            // Call the API to perform the 'stand' action
            var response = await _apiClient.PostAsync($"Game/stand/{userId}", null);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the updated GameState from the API response
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                var updatedGameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);

                // Update the specific GameState in the list
                var index = gameStates.FindIndex(gs => gs.UserId == updatedGameState.UserId);
                if (index >= 0)
                {
                    gameStates[index] = updatedGameState; // Replace the matching state
                }

                // Save the updated list back to the session
                HttpContext.Session.SetString("GameState", JsonConvert.SerializeObject(gameStates));
            }
            else
            {
                ViewBag.Error = "Failed to perform stand action.";
            }

            return View("GameIndex", gameStates);
        }

    }
}
