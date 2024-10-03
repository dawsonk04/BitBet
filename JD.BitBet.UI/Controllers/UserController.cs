using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
