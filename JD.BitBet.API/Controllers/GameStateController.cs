using JD.BitBet.BL.Models;
using JD.BitBet.BL;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStateController : GenericController<Hand, GameStateManager, BitBetEntities>
    {
        public GameStateController(ILogger<GameStateController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) { }
    }

}
