using eLog.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eLog.Web.Controllers
{
    [Route("api/auth")]
    [ApiController]
   
    public class RegistrationController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            if (user == null)
                return BadRequest("Invalid client request");
            if(user.UserName == "johndoe" && user.UserPassword == "def@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44398",
                    audience: "https://localhost:44398",
                    claims: new List<Claim>(),  
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);   
                return Ok(new { Token = tokenString }); 
            } 
            return Unauthorized();  
        }

    }

}
