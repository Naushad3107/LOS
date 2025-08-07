using LOS.DTO.UserRoleDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        IUserRole service;
        public UserRoleController(IUserRole service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddUserRole")]
        public IActionResult AddUserRole(AddUserRoleDTO role)
        {
            if (role == null)
            {
                return BadRequest("Role data is null");
            }
            service.AddUserRole(role);
            return Ok(new { message = "User role added successfully" });
        }
        [HttpGet]
        [Route("FetchUserRoles")]
        public IActionResult UserRoles()
        {
            var data = service.FetchUserRoles();
            return Ok(data);
        }
    }
}
