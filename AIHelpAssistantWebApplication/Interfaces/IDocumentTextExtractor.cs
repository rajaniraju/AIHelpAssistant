namespace AIHelpAssistantWebApplication.Interfaces
{
    public interface IDocumentTextExtractor
    {
        
            Task<string> ExtractTextAsync(
                Stream stream,
                CancellationToken cancellationToken = default);
        }
    }


