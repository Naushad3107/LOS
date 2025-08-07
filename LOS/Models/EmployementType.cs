using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class EmployementType
    {
        [Key]
        public int EmployeementTypeId { get; set; }

        public string TypeCode { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; }
        public Byte IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; }

    }
}
