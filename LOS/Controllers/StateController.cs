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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try
            {
                service.DeleteState(id);
                return Ok(new { message = " Role Is Deleted" });
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

        [HttpGet]
        [Route("FindStateById")]
        public IActionResult FindStateById(int id)
        {
           var data = service.FindStateById(id);
            if(data == null)
            {
                return BadRequest( " State Not Found");
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateState")]
        public IActionResult UpdateState(UpdateStateDTO state) {
            if (state == null)
            {
                return BadRequest("State data is null");
            }
            else if (state.StateId <= 0)
            {
                return BadRequest("Invalid State ID");
            }
            else
            {
                var existingState = service.FindStateById(state.StateId);
                if (existingState == null)
                {
                    return NotFound("State not found");
                }
                else
                {
                    service.UpdateState(state);
                    return Ok(new { message = "State updated successfully" });
                }
            }
        }
    }
}
