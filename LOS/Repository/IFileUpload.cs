using LOS.DTO.DocumentDTOs;
using LOS.DTO.DocumetDTOs;

namespace LOS.Repository
{
    public interface IFileUpload
    {
        public void UploadFile(UploadDocumentDTO file);

        List<FetchFileDTO> AllFiles();
    }
}
