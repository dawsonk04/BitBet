﻿using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using WebApi.Services;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User, UserManager, BitBetEntities>
    {
        private IUserService _userService;
        private readonly ILogger<UserController> logger;
        private readonly DbContextOptions<BitBetEntities> options;
        UserManager userManager;
        WalletManager walletManager;
        public UserController(IUserService userService, ILogger<UserController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) 
        {
            this._userService = userService;
            this.options = options;
            this.logger = logger;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                logger.LogWarning("Authentication unsuccessful for {UserName}", model.Email);
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            logger.LogWarning("Authentication successful for {UserName}", model.Email);
            return Ok(response);
        }
        [HttpPut("updateBet/{userId}")]
        public async Task<IActionResult> UpdateUserBet([FromRoute] Guid UserId, [FromBody] double betAmount)
        {
            userManager = new UserManager(options);
            walletManager = new WalletManager(options);
            User user = await userManager.LoadByIdAsync(UserId);
            Wallet userWallet = await walletManager.LoadByUserIdAsync(UserId);
            if (user != null)
            {
                user.BetAmount = betAmount;
                userWallet.Balance -= betAmount;
                user.HasBet = true;
                await walletManager.UpdateAsync(userWallet);
                await userManager.UpdateAsync(user);
            }
            return Ok();
        }
        [HttpGet("getPlayers/{gameId}")]
        public async Task<IActionResult> getPlayersInGame([FromRoute] Guid gameId)
        {
            userManager = new UserManager(options);
            List<User> users = await userManager.LoadByGameAsync(gameId);
            return Ok(users);
        }
    }
}
