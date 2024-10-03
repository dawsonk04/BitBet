using JD.BitBet.BL.Models;
using JD.BitBet.UI.Extensions;

namespace JD.BitBet.UI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated( HttpContext context)
        {
            if(context.Session.GetObject<User>("user") != null) 
            {
                return true;
            }
            return false;
        }
    }
}
