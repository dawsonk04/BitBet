using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : GenericController<Game, GameManager, BitBetEntities>
    {
        GameManager gameManager;
        public GameController(ILogger<GameController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options)
        {

        }

        [HttpPost("start")]
        public async Task<IActionResult> StartNewGame()
        {
            try
            {
                gameManager = new GameManager(options);
                GameState gameState = await gameManager.StartNewGame();
                return Ok(gameState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("hit")]
        public IActionResult Hit(GameManager gameManager)
        {
            try
            {
                gameManager.Hit();
                return Ok(GameManager.State);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("stand")]
        public IActionResult Stand(GameManager gameManager)
        {
            try
            {
                gameManager.Stand();
                return Ok(GameManager.State);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("double/{handId}")]
        public IActionResult Double(Guid handId, GameManager gameManager)
        {
            try
            {
                gameManager.Double(handId);
                return Ok(GameManager.State);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("split/{handId}")]
        public IActionResult Split(Guid handId, GameManager gameManager)
        {
            try
            {
                gameManager.Split(handId);
                return Ok(GameManager.State);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("state")]
        public IActionResult GetGameState()
        {
            try
            {
                return Ok(GameManager.State);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
