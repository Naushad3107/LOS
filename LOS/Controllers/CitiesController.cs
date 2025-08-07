using LOS.DTO.CitiesDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICities service;
        public CitiesController(ICities service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddCity")]
        public IActionResult AddCities(AddCitiesDTO city)
        {
            try
            {
                service.AddCities(city);
                return Ok(new { message = "City added successfully" });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("AllCities")]
        public IActionResult GetCities()
        {
            try
            {
                var cities = service.GetCities();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCity(int id)
        {
            try
            {
                service.DeleteCity(id);
                return Ok(new { message = "City Deleted Sucessfully" });
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
