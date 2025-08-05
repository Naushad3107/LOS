using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }


    }
}
