using AutoMapper;
using LOS.Data;
using LOS.DTO.DocumentDTOs;
using LOS.DTO.DocumetDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Service
{
    public class FileUploadService : IFileUpload
    {
        ApplicationDbContext db;
        IWebHostEnvironment env;
        IMapper mapper;
        public FileUploadService(ApplicationDbContext db, IWebHostEnvironment env,IMapper mapper)
        {
            this.db = db;
            this.env = env;
            this.mapper = mapper;
        }
        public void UploadFile(UploadDocumentDTO file)
        {
            string webRootPath = env.WebRootPath;


            string originalFileName = Path.GetFileName(file.DocumentPath.FileName);
            string filepath = "uploads/" + originalFileName;
            string UploadPath = Path.Combine(webRootPath, filepath);

            UploadDocument(file.DocumentPath, UploadPath);

            var document = new DocumentUpload
            {
                DocumentName = file.DocumentName, 
                DocumentPath = filepath,         
                IsDeleted = 0
            };
            db.documents.Add(document);
            db.SaveChanges();
        }


        [NonAction]
        public void UploadDocument(IFormFile file, string fullPath)
        {
            if (file != null && file.Length > 0)
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }

        public List<FetchFileDTO> AllFiles()
        {
            var documents = db.documents.Where(x => x.IsDeleted == 0).ToList();
            var map = mapper.Map<List<FetchFileDTO>>(documents);
            return map;
        }
    }
}
