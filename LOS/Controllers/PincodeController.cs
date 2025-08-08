using LOS.DTO.PincodeDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : ControllerBase
    {
        IPincode service;
        public PincodeController(IPincode service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddPincode(AddPinCodeDTO pincode)
        {
            if (pincode == null)
            {
                return BadRequest("Pincode cannot be null or empty");
            }
            else
            {
                service.AddPincode(pincode);
                return Ok(new { message = "Pincode added successfully", pincode });
            }
        }

        [HttpGet]
        [Route("AllPincode")]
        public IActionResult GetAllPincodes()
        {
            var pincodes = service.FetchPinCode();
            if (pincodes == null || !pincodes.Any())
            {
                return NotFound(new { message = "No pincodes found" });
            }
            return Ok(pincodes);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePincode(int id)
        {
            try
            {
                service.DeletePincode(id);
                return Ok(new { message = "Pincode deleted successfully" });
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(new { message = knf.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("PincodeById/{id}")]
        public IActionResult GetPincodeById(int id)
        {
            var pincode = service.FindPincodeById(id);
            if (pincode == null)
            {
                return NotFound(new { message = "Pincode not found" });
            }
            return Ok(pincode);
        }
    }
}
