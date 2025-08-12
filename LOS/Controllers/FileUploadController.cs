using LOS.Data;
using LOS.DTO.DocumetDTOs;
using LOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        IFileUpload service;
        ApplicationDbContext db;
        public FileUploadController(IFileUpload service,ApplicationDbContext db)
        {
            this.db = db;
            this.service = service;
        }

        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile(UploadDocumentDTO file)
        {
            if (file == null || file.DocumentPath == null || string.IsNullOrEmpty(file.DocumentName))
            {
                return BadRequest("Invalid file upload request.");
            }
            try
            {
                service.UploadFile(file);
                return Ok("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("AllFiles")]
        public IActionResult GetAllFiles()
        {
            try
            {
                var files = service.AllFiles();
                if (files == null || files.Count == 0)
                {
                    return NotFound("No files found.");
                }
                return Ok(files);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving files: {ex.Message}");
            }
        }

        [HttpDelete("DeleteMultiple")]
        public IActionResult DeleteMultiple([FromBody] List<int> FileId)
        {
            if (FileId == null || !FileId.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var itemsToDelete = db.documents
                .Where(img => FileId.Contains(img.DocumentId))
                .ToList();

            if (!itemsToDelete.Any())
            {
                return NotFound("No matching images found.");
            }

            itemsToDelete.ForEach(img => img.IsDeleted = 1); 
            db.SaveChanges();

            return Ok(new { message = $"{itemsToDelete.Count} images deleted successfully." });
        }
    }
}
