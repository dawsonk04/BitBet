using JD.BitBet.API.Hubs;
using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : GenericController<Game, GameManager, BitBetEntities>
    {
        GameManager gameManager;
        IHubContext<BlackJackHub> _hubContext;
        public GameController(ILogger<GameController> logger, DbContextOptions<BitBetEntities> options/*, IHubContext<BlackJackHub> hubContext*/) : base(logger, options)
        {
            //_hubContext = hubContext;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartNewGame(/*Game game*/)
        {
            try
            {
                gameManager = new GameManager(options);
                //await gameManager.InsertAsync(game);
                GameState gameState = await gameManager.StartNewGame();
                //await _hubContext.Clients.Group(game.Id.ToString()).SendAsync("GameStateUpdated", gameState);
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
