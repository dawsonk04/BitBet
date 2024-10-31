using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
