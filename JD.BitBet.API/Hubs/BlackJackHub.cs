using Microsoft.AspNetCore.SignalR;
using System.IO;

namespace JD.BitBet.API.Hubs
{
    public class BlackJackHub : Hub
    {
        public async Task SendMessage(string User, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", User, message);
        }
    }
}
