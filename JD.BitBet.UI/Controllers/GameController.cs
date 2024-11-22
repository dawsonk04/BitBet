using JD.BitBet.BL.Models;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.UI.Controllers
{
    public class GameController : GenericController<Game>
    {
        private readonly ApiClient _apiClient;
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

        public async Task<IActionResult> Start()
        {
            var response = await _apiClient.PostAsync("Game/start", null);
            return RedirectToAction("GameIndex");
        }

        public async Task<IActionResult> Hit()
        {
            var response = await _apiClient.PostAsync("Game/hit", null);
            return RedirectToAction("GameIndex");
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
