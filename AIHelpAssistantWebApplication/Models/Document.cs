namespace AIHelpAssistantWebApplication.Models
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FileName { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public long FileSizeBytes { get; set; }


        public string? StoragePath { get; set; }
        public string Status { get; set; } = "Uploaded";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // One document can contain multiple chunks
        public ICollection<DocumentChunk> Chunks { get; set; }
            = new List<DocumentChunk>();


    }
}
