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
        GameStateManager gameStateManager;
        UserManager userManager;
        IHubContext<BlackJackHub> _hubContext;
        public GameController(ILogger<GameController> logger, DbContextOptions<BitBetEntities> options, IHubContext<BlackJackHub> hubContext) : base(logger, options)
        {
            _hubContext = hubContext;
        }
        [HttpPost("loadstate/{gameId}")]
        public async Task<IActionResult> LoadCurrentGame([FromRoute] Guid gameId)
        {
            try
            {
                gameStateManager = new GameStateManager(options);
                List<GameState> gameStates = await gameStateManager.LoadByGameIdAsync(gameId);
                if(gameStates != null)
                {
                    return Ok(gameStates);
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
        [HttpPost("start/{gameId}")]
        public async Task<IActionResult> StartNewGame([FromRoute] Guid gameId)
        {
            try
            {
                gameManager = new GameManager(options);
                userManager = new UserManager(options);
                Game game = await gameManager.LoadByIdAsync(gameId);
                game.Users = await userManager.LoadByGameAsync(gameId);
                List<GameState> gameState = await gameManager.StartNewGame(game);
                await _hubContext.Clients.Group(game.Id.ToString()).SendAsync("GameStateUpdated", gameState);
                return Ok(gameState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("join/{gameId}/{UserId}")]
        public async Task<IActionResult> JoinGame([FromRoute] Guid gameId, [FromRoute] Guid UserId)
        {
            try
            {
                gameManager = new GameManager(options);
                userManager = new UserManager(options);
                User user = await userManager.LoadByIdAsync(UserId);
                var game = await gameManager.LoadByIdAsync(gameId);
                user.gameId = gameId;
                await userManager.UpdateGameId(user);
                game.Users = await userManager.LoadByGameAsync(game.Id);
                if (game == null)
                {
                    return NotFound("Game not found.");
                }
                if (game.Users == null)
                {
                    game.Users = new List<User>();
                }
                await gameManager.UpdateAsync(game);
                await _hubContext.Clients.Group(gameId.ToString()).SendAsync("UserJoined", user);

                return Ok(game);
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
        [HttpPost("stand/{userId}")]
        public async Task<IActionResult> StandPlayerHand([FromRoute] Guid UserId)
        {
            try
            {
                gameStateManager = new GameStateManager(options);
                gameManager = new GameManager(options);

                GameState state = await gameStateManager.LoadByUserIdAsync(UserId);
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
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // for inital screen loading the games onto the UI
        [HttpGet("getgames")]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                gameManager = new GameManager(options);
                var games = await gameManager.LoadAsync();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);                
            }
        }

    }
}
