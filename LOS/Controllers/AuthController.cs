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

            var result = token.Result;
            if (result == null) {

                return BadRequest("Enter Valid Credentials");

            }else if(result == "Invalid Credentials")
            {
                return BadRequest("Invalid Credentials");
            }else if(result =="Invalid Password")
            {
                return BadRequest("Invalid Password");
            }
                return Ok(new
                {
                    access_token = token,
                    token_type = "Bearer",

                });
        }
    }
}
