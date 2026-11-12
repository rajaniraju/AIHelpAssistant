
using AIHelpAssistantWebApplication.Interfaces;
using System.Text;

namespace AIHelpAssistantWebApplication.Services
{
    public class PlainTextExtractor : IDocumentTextExtractor
    {
        public async Task<string> ExtractTextAsync(
            Stream stream,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (stream.CanSeek)
            {
                stream.Position = 0;
            }

            using var reader = new StreamReader(
                stream,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true,
                leaveOpen: true);

            return await reader.ReadToEndAsync(cancellationToken);
        }
    }
}

