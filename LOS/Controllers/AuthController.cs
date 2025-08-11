using LOS.DTO.LoginDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LOS.Controllers
{
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
            var token = auth.Login(login.Email,login.Password);

            if (token == null) {
                return Unauthorized();
            }

            var exp = int.Parse(config.GetSection("JwtSettings")["ExpiryInMinutes"] ?? "60");

            return Ok(new
            {
                access_token = token,
                token_type = "Bearer",
                expires_in = exp
            });
        }
    }
}
