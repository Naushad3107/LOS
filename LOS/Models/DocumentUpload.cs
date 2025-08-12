using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class DocumentUpload
    {
        [Key]
        public int DocumentId { get; set; }

        public string? DocumentName { get; set; }

        public string? DocumentPath { get; set; }

        public Byte IsDeleted { get; set; } = 0;

    }
}
