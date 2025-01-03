using JD.BitBet.BL.Models;
using JD.BitBet.UI.Controllers;
using JD.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JD.BitBet.UI.ViewComponents
{
    public class WalletViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _apiClient = new ApiClient("https://localhost:7061/api");
            HttpContextAccessor _contextAccessor = new HttpContextAccessor();
            var userId = _contextAccessor.HttpContext?.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return View("Login");
            }
            ViewBag.UserId = userId;
            var walletresponse = await _apiClient.GetAsync($"https://localhost:7061/api/Wallet/user/{userId}");
            if (walletresponse != null)
            {
                var walletContent = await walletresponse.Content.ReadAsStringAsync();
                var wallet = JsonConvert.DeserializeObject<Wallet>(walletContent);
                ViewBag.UserWallet = wallet;
                return View(wallet);
            }
            return View();
        }
    }
}
