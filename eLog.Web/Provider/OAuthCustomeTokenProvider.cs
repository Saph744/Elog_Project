using Microsoft.AspNetCore.Authentication;
//using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace eLog.Web.Provider
{
    public class OAuthCustomeTokenProvider
    {
        //public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        //{
        //    var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
        //    newIdentity.AddClaim(new Claim("newClaim", "refreshToken"));

        //    var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
        //    context.Validated(newTicket);

        //    return Task.FromResult<object>(null);
        //}

    }
   

}
