using AIHelpAssistantWebApplication.Interfaces;
using System.Text;
using UglyToad.PdfPig;

namespace AIHelpAssistantWebApplication.Services
{
    
        public class PdfTextExtractor : IDocumentTextExtractor
        {
            public Task<string> ExtractTextAsync(
                Stream stream,
                CancellationToken cancellationToken = default)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var text = new StringBuilder();

                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }

                using (var pdf = PdfDocument.Open(stream))
                {
                    foreach (var page in pdf.GetPages())
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        text.AppendLine(page.Text);
                    }
                }

                return Task.FromResult(text.ToString());
            }
        }
    }


