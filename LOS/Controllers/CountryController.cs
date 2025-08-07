using LOS.DTO.CountryDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountries service;
        public CountryController(ICountries service) 
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddCountry")]
        public IActionResult AddCountry(AddCountryDTO country)
        {
            if (country == null)
            {
                return BadRequest(new { message = "Country data cannot be null" });
            }
            else {

                service.AddCountry(country);
                return Ok(new { message = "Country added successfully" });
            }

        }

        [HttpGet]
        [Route("ShowCountries")]
        public IActionResult GetCountry() 
        {
            var data = service.GetCountries();
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteCountries")]
        public IActionResult DeleteCountry(int id) 
        {
            service.DeleteCountry(id);
            return Ok(new { message = "Country Deleted" });
        }
    }
}
