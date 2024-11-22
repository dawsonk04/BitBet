using DocumentFormat.OpenXml.Spreadsheet;
using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.UI.Extensions;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace JD.BitBet.UI.Controllers
{
    public class UserController : GenericController<User>
    {
        private readonly ApiClient _apiClient;
        public UserController(HttpClient httpClient) : base(httpClient)
        {
        }
        //private readonly UserManager _userManager = new UserManager();
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //private void SetUser(User user)
        //{

        //    HttpContext.Session.SetObject("user", user);

        //    if (user != null)
        //    {
        //        HttpContext.Session.SetObject("email", "Welcome " + user.Email);
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetObject("email", string.Empty);
        //    }
        //}

        //public IActionResult Logout()
        //{
        //    SetUser(null);
        //    return View();
        //}

        //public IActionResult Seed()
        //{
        //    _userManager.Seed();
        //    return View();
        //}


        //public IActionResult Login(string returnUrl)
        //{

        //    TempData["returnUrl"] = returnUrl;
        //    ViewBag.Title = "Login";
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                // Call the API with the user model for authentication
                var jsonContent = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _apiClient.PostAsync("User/Authenticate", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var authenticatedUser = JsonConvert.DeserializeObject<User>(jsonResponse);

                    // Store user details in session
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(authenticatedUser));

                    return RedirectToAction("Index", "Game");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(user); // Return to the login view
        }

    }
}
