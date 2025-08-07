using LOS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.DTO.CitiesDTOs
{
    public class GetCitiesDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        
        public int StateId { get; set; }

        public Byte IsActive { get; set; }

        // Navigation 
        public string StateName { get; set; }


        public string Pincodes { get; set; }
    }
}
