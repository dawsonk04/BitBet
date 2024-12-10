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

                ViewBag.UserId = userId;
                var gameDetailsResponse = await _apiClient.GetAsync($"Game/{gameId}");
                var gameDetails = await gameDetailsResponse.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("CurrentGame", gameDetails);
                var game = JsonConvert.DeserializeObject<Game>(gameDetails);
                ViewBag.GameDetails = game;

                var loadStateResponse = await _apiClient.GetAsync($"Game/loadstate/{gameId}");

                if (loadStateResponse.IsSuccessStatusCode)
                {

                    var responseData = await loadStateResponse.Content.ReadAsStringAsync();
                    var allGameStates = JsonConvert.DeserializeObject<List<GameState>>(responseData);

                    var activeGameStates = allGameStates.Where(g => !g.isGameOver).ToList();
                    HttpContext.Session.SetString("GameStates", JsonConvert.SerializeObject(activeGameStates));

                    var userGameState = activeGameStates.FirstOrDefault(gs => gs.UserId.ToString() == userId);
                    HttpContext.Session.SetString("GameState", JsonConvert.SerializeObject(userGameState));

                    var joinResponse = await _apiClient.PostAsync($"Game/join/{gameId}/{userId}", null);
                    if (joinResponse.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "You have successfully joined the game!";
                        return View("GameIndex", activeGameStates);
                    }
                    else
                    {
                        ViewBag.Error = "Unable to join the game.";
                        return RedirectToAction("GameList", "Game");
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
            var gameJson = HttpContext.Session.GetString("CurrentGame");
            var game = JsonConvert.DeserializeObject<Game>(gameJson);
            ViewBag.GameDetails = game;
            var gameId = game.Id;

            var currentGameJson = HttpContext.Session.GetString("CurrentGame");
            Game currentGame = JsonConvert.DeserializeObject<Game>(currentGameJson);

            if (currentGame.isGameOver)
            {
                currentGame.isGameOver = false;
                HttpContext.Session.SetString("CurrentGame", JsonConvert.SerializeObject(currentGame));
                ViewBag.GameDetails = currentGame;
            }

            var response = await _apiClient.PostAsync($"Game/start/{gameId}", null);
            var gameStateJson = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("GameStates", gameStateJson);
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
            var gameStateJson = HttpContext.Session.GetString("GameStates");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return RedirectToAction("GameIndex");
            }
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.UserId = userId;

            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            var content = new StringContent(JsonConvert.SerializeObject(gameStates), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync($"Game/hit/{userId}", null);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                var updatedGameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);

                var index = gameStates.FindIndex(gs => gs.UserId == updatedGameState.UserId);
                if (index >= 0)
                {
                    gameStates[index] = updatedGameState;
                }
                HttpContext.Session.SetString("GameStates", JsonConvert.SerializeObject(gameStates));
            }
            else
            {
                ViewBag.Error = "Failed to perform hit action.";
            }
            await checkGameStatus();
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
            await checkGameStatus();
            return View("GameIndex", gameStates);
        }
        public async Task<IActionResult> Stand()
        {

            var gameStateJson = HttpContext.Session.GetString("GameStates");
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
            ViewBag.UserId = userId;
            var response = await _apiClient.PostAsync($"Game/stand/{userId}", null);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                var updatedGameState = JsonConvert.DeserializeObject<GameState>(updatedGameStateJson);
                var index = gameStates.FindIndex(gs => gs.UserId == updatedGameState.UserId);
                if (index >= 0)
                {
                    gameStates[index] = updatedGameState;
                }

                HttpContext.Session.SetString("GameStates", JsonConvert.SerializeObject(gameStates));
            }
            else
            {
                ViewBag.Error = "Failed to perform stand action.";
            }
            if (gameStates.All(e => e.isGameOver == true))
            {
                await PerformDealerTurn();
                var gameStatescontent = HttpContext.Session.GetString("GameStates");
                gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStatescontent);
            }
            await checkGameStatus();
            return View("GameIndex", gameStates);
        }
        public async Task PerformDealerTurn()
        {
            var gameStatescontent = HttpContext.Session.GetString("GameStates");
            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStatescontent);

            var response = await _apiClient.PostAsync($"Game/dealerTurn/{gameStates[0].dealerHandId}", null);

            if (response.IsSuccessStatusCode)
            {
                var updatedGameStateJson = await response.Content.ReadAsStringAsync();
                var updatedGameStates = JsonConvert.DeserializeObject<List<GameState>>(updatedGameStateJson);

                HttpContext.Session.SetString("GameStates", JsonConvert.SerializeObject(updatedGameStates));
            }
            else
            {
                ViewBag.Error = "Failed to perform dealer's turn.";
            }
        }
        public async Task checkGameStatus()
        {
            var gameStateJson = HttpContext.Session.GetString("GameStates");
            if (string.IsNullOrEmpty(gameStateJson))
            {
                return;
            }

            var gameStates = JsonConvert.DeserializeObject<List<GameState>>(gameStateJson);
            var activeGames = gameStates.Where(g => !g.isGameOver).ToList();
            HttpContext.Session.SetString("GameStates", JsonConvert.SerializeObject(activeGames));

            var currentGameJson = HttpContext.Session.GetString("CurrentGame");
            Game currentGame = JsonConvert.DeserializeObject<Game>(currentGameJson);

            if (!activeGames.Any())
            {
                currentGame.isGameOver = true;
                HttpContext.Session.SetString("CurrentGame", JsonConvert.SerializeObject(currentGame));
            }
            ViewBag.GameDetails = currentGame;
        }
    }
}
