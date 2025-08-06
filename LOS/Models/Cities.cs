using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.Models
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public Byte IsActive { get; set; } 

        // Navigation 
        public States State { get; set; }

        public List<Cities> cities { get; set; }

        public List<PincodeMaster> Pincodes { get; set; }
    }
}
