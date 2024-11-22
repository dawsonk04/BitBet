using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userManager;
        public IActionResult Index()
        {
            return View();
        }
        private void SetUser(User user)
        {

            HttpContext.Session.SetObject("user", user);

            if (user != null)
            {
                HttpContext.Session.SetObject("email", "Welcome " + user.Email);
            }
            else
            {
                HttpContext.Session.SetObject("email", string.Empty);
            }
        }

        public IActionResult Logout()
        {
            SetUser(null);
            return View();
        }

        public IActionResult Seed()
        {
            _userManager.Seed();
            return View();
        }


        public IActionResult Login(string returnUrl)
        {

            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                bool result = await _userManager.LoginAsync(user);
                SetUser(user);
                if (TempData["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());

                return RedirectToAction("Index", "Game");
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }
    }
}
