using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.DTO.StateDTOs
{
    public class AddStateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        
        public int CountryId { get; set; }
    }
}
