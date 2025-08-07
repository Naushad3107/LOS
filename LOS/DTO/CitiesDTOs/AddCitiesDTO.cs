using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.DTO.CitiesDTOs
{
    public class AddCitiesDTO
    {
       
        public int CityId { get; set; }
        public string CityName { get; set; }

        
        public int StateId { get; set; }

        public string StateName { get; set; }

        public Byte IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
