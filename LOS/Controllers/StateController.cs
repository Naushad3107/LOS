using LOS.DTO.StateDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        IState service;
        public StateController(IState service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddState(AddStateDTO state)
        {
            if (state == null)
            {
                return BadRequest("State data is null");
            }
            service.AddState(state);
            return Ok(new { message = "State added successfully" });

        }

        [HttpGet]
        [Route("FetchState")]
        public IActionResult FetchStates()
        {
            var data = service.FetchStates();
            if (data == null)
            {
                return NotFound("No states found");
            }
            return Ok(data);
        }

        
    }
}
