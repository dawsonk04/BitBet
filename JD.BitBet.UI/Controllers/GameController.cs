using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.UI.Controllers
{
    public class GameController : Controller
    {
        private readonly HttpClient _httpClient;

        public GameController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7061/api/Game/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("state");
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
            var response = await _httpClient.PostAsync("start", null);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Hit()
        {
            var response = await _httpClient.PostAsync("hit", null);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Stand()
        {
            var response = await _httpClient.PostAsync("stand", null);
            return RedirectToAction("Index");
        }

        public void Double()
        {

        }

        public void Split()
        {

        }

    }
}
