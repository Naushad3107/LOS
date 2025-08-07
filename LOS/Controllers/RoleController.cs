using LOS.DTO.RoleDTOs;
using LOS.Repository;
using LOS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole service;
        public RoleController(IRole service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole([FromBody] AddRoleDTO role)
        {
            if (role == null)
            {
                return BadRequest("Role data is null");
            }
            try
            {
                service.AddRole(role);
                return Ok(new { message = "Role added successfully" });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpGet]
        [Route("FetchRole")]
        public IActionResult FetchRoles()
        {
            var roles = service.FetchRoles();
            return Ok(roles);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
               service.DeleteRole(id);
                return Ok(new {message= " Role Is Deleted"}); 
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(new { message = knf.Message });
            }
            catch (InvalidOperationException ioe)
            {

                return Conflict(new { message = ioe.Message }); 
            }
        }

    }
}
