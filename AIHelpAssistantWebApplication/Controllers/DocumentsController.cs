using AIHelpAssistantWebApplication.Data;
using AIHelpAssistantWebApplication.Models;
using AIHelpAssistantWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace AIHelpAssistantWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly DocumentExtractionService _documentExtractionService;
        private readonly TextChunkingServices _textChunkingService;

        public DocumentsController(
            ApplicationDbContext context,
            IWebHostEnvironment environment,
            DocumentExtractionService documentExtractionService,
            TextChunkingServices textChunkingService)
        {
            _context = context;
            _environment = environment;
            _documentExtractionService = documentExtractionService;
            _textChunkingService = textChunkingService;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadDocument(
        IFormFile file,
        CancellationToken cancellationToken)
        {
            using var stream = file.OpenReadStream();
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a valid file.");
            }
            var fileExtension = Path.GetExtension(file.FileName);

            var extractedText = await _documentExtractionService.ExtractTextAsync(
                stream,
                fileExtension,
                cancellationToken);
            var document = new Document
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileSizeBytes = file.Length,
                Status = "Extracted",
                CreatedAt = DateTime.UtcNow
            };
            var chunks = _textChunkingService.SplitIntoChunks(extractedText);
            var documentChunks = chunks.Select((content, index) => new DocumentChunk {DocumentId=document.Id,ChunkIndex=index,Content=content,TokenCount=null }).ToList();
            // Add document
            await _context.Documents.AddAsync(document, cancellationToken);

            // Add all chunks
            _context.DocumentChunks.AddRange(documentChunks);

            // Save everything
            var rowsAffected = await _context.SaveChangesAsync(cancellationToken);
            return Ok(new
            {
                FileName = file.FileName,
                FileSize = file.Length,
                ContentType = file.ContentType,
                ExtractedText = extractedText,
                RowsAffected = rowsAffected,
               
                Chunks = chunks
            });
        }
    }
}
