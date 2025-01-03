using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : GenericController<Wallet, WalletManager, BitBetEntities>
    {
        UserManager userManager;
        WalletManager walletManager;
        public WalletController(ILogger<WalletController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) { }

        [HttpGet("user/{UserId}")]
        public async Task<IActionResult> LoadCurrentGame([FromRoute] Guid UserId)
        {
            try
            {
                walletManager = new WalletManager(options);
                Wallet wallet = await walletManager.LoadByUserIdAsync(UserId);
                if (wallet != null)
                {
                    return Ok(wallet);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
     }
}
