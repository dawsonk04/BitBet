using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandController : GenericController<Hand, HandManager, BitBetEntities>
    {
        public HandController(ILogger<HandController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) { }

    }
}
