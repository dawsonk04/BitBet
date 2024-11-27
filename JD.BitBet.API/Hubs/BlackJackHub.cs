using JD.BitBet.BL.Models;
using Microsoft.AspNetCore.SignalR;

namespace JD.BitBet.API.Hubs
{
    public class BlackJackHub : Hub
    {
        public async Task SendMessage(string User, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", User, message);
        }

        public async Task JoinGame(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).SendAsync("PlayerJoined", Context.ConnectionId);
        }

        public async Task UpdateGameState(string gameId, GameState gameState)
        {
            await Clients.Group(gameId).SendAsync("GameStateUpdated", gameState);
        }
        public async Task LeaveGame(string gameId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).SendAsync("PlayerLeft", Context.ConnectionId);
        }

    }
}
