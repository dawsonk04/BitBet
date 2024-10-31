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
        public WalletController(ILogger<WalletController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) { }

    }
}
