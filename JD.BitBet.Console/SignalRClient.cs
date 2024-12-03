using JD.Utility;

namespace JD.BitBet.Console
{
    public class SignalRClient : SignalRConnection
    {
        public SignalRClient(string hubAddress) : base(hubAddress)
        {

        }
        public SignalRClient(string hubAddress, string owner) :
           base(hubAddress, owner)
        {

        }
    }
}
