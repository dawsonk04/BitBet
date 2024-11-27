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
        public async Task<IActionResult> HitPlayerHand(GameState state)
        {
            try
            {
                gameManager = new GameManager(options);
                GameState gameState = await gameManager.Hit(state);
                return Ok(gameState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("stand")]
        public async Task<IActionResult> StandPlayerHand(GameState state)
        {
            try
            {
                gameManager = new GameManager(options);
                GameState gameState = await gameManager.Stand(state);
                return Ok(gameState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("double")]
        public async Task<IActionResult> DoublePlayerHand(GameState state)
        {
            try
            {
                gameManager = new GameManager(options);
                GameState gameState = await gameManager.Double(state);
                return Ok(gameState);
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
