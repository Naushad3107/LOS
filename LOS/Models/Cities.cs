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

        public bool IsActive { get; set; } = true;

        // Navigation 
        public States State { get; set; }
    }
}
