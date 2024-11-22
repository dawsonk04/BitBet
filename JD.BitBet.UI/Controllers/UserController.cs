﻿using DocumentFormat.OpenXml.Spreadsheet;
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
            this._apiClient = new ApiClient(httpClient.BaseAddress.AbsoluteUri);

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
                    return RedirectToAction("Index", "Game"); // Redirect to the game index
                }
                Console.WriteLine("Error: Unable to parse user details.");
            }
            else
            {
                Console.WriteLine($"Login failed. {response.StatusCode}: {responseContent}");
            }
            return View(user); // Return the login view if model state is invalid or login failed
        }
    }
}

