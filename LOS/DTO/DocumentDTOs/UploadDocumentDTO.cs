namespace LOS.DTO.DocumetDTOs
{
    public class UploadDocumentDTO
    {
        public int DocumentId { get; set; }

        public string? DocumentName { get; set; }


        public IFormFile DocumentPath { get; set; }

    }
}
