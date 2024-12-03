using Microsoft.AspNetCore.SignalR.Client;

namespace JD.Utility
{
    public class SignalRConnection
    {
        private string hubAddress;
        HubConnection _connection;
        public string User { get; set; }
        public string Message { get; set; }
        string owner;

        public SignalRConnection(string hubAddress)
        {
            this.hubAddress = hubAddress;
        }
        public SignalRConnection(string hubAddress, string owner)
        {
            this.hubAddress = hubAddress;
            this.owner = owner;
        }

        public HubConnection HubConnection
        {
            get { return _connection; }
        }

        public void SendAction(string action)
        {
            try
            {
                Console.WriteLine($"Sending action: {action}");
                _connection.InvokeAsync("PlayerAction", owner, action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void JoinGame(string gameId)
        {
            try
            {
                _connection.InvokeAsync("JoinGame", gameId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /* will still need more methods in here likely for start, end, update game */

    }
}
