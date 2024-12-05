using JD.BitBet.BL.Models;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace JD.BitBet.UI.Controllers
{
    public class UserController : GenericController<User>
    {
        private readonly ApiClient _apiClient;
        public UserController(HttpClient httpClient) : base(httpClient)
        {
            this._apiClient = new ApiClient(httpClient.BaseAddress.AbsoluteUri);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {

            var jsonContent = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync("User/Authenticate", httpContent);

            // Log response status and message for debugging
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response content
                var authenticatedUser = JsonConvert.DeserializeObject<User>(responseContent);
                if (authenticatedUser != null)
                {
                    HttpContext.Session.SetString("UserId", authenticatedUser.Id.ToString());
                    return RedirectToAction("GameList", "Game");
                }
                Console.WriteLine("Error: Unable to parse user details.");
            }
            else
            {
                Console.WriteLine($"Login failed. {response.StatusCode}: {responseContent}");
            }
            return View(user);
        }
    }
}

