using eLog.Domain.Data;
using eLog.Domain.Models;
using eLog.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
     [HttpGet]
     [Authorize]
     public IEnumerable<string> Get()
        
            => new string[] { "John Doe", "Jane Doe" };
        

    
    }
}



