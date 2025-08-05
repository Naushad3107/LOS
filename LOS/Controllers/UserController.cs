using LOS.DTO.USERDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(AddUserDTO u)
        {
            if (u == null)
            {
                return BadRequest("User data is null");
            }
            userService.AddUser(u);
            return Ok(new { message = "User added successfully" });
        }

        [HttpGet]
        [Route("FetchUsers")]
        public IActionResult FetchAllUsers()
        {
            var user = userService.FetchUser();
            return Ok(user);
        }

        [HttpPut("UpdateUser/{id}")]
       
        public IActionResult UpdateUserDetails(int id, UpdateUserDTO m)
        {
            var updateuser = userService.FetchUserById(id);
            if (updateuser == null)
            {
                return NotFound(new { message = "User not found" });
            }else if (m == null)
            {
                return BadRequest("User data is null");
            }
            else
            {

                userService.UpdateUserDetails(m,id);
            }


            return Ok(new { message = "Updated user details" });
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = userService.FetchUserById(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            userService.DeleteUser(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
