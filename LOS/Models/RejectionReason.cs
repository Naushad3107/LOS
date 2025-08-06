using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class RejectionReason
    {
        [Key]
        public int ReasonId { get; set; }

        public string ReasonCode { get; set; }

        public string ReasonText { get; set; }

        public string Category { get; set; }

        public Byte IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; }
    }
}
