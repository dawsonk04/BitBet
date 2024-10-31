using Microsoft.AspNetCore.Mvc;

namespace JD.BitBet.API.Controllers
{
    public class WalletController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
