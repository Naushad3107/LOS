using LOS.DTO.LoginDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LOS.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        IAuth auth;
        IConfiguration config;

        public AuthController(IAuth auth, IConfiguration config)
        {
            this.auth = auth;
            this.config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Auth(LoginDTO login)
        {
            if (login == null)
            {
                return BadRequest("Please Enter Credentials");
            }
            var token = await auth.Login(login.Email,login.Password);


            if (string.IsNullOrEmpty(token) || token.Contains("Invalid"))
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }
            return Ok(new
                {
                    token
                });
        }
    }
}
