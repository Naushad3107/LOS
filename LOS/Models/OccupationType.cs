using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class OccupationType
    {
        [Key]
        public int OccupationTypeId { get; set; }
        public string OccupationCode { get; set; }
        public string OccupationName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }
    }
}
