using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using AIHelpAssistantWebApplication.Interfaces;

namespace AIHelpAssistantWebApplication.Services
{
    public class WordTextExtractor : IDocumentTextExtractor

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

            using (var wordDoc = WordprocessingDocument.Open(stream, false))
            {
                var body = wordDoc.MainDocumentPart?.Document?.Body;

                if (body != null)
                {
                    foreach (var paragraph in body.Elements<Paragraph>())
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        text.AppendLine(paragraph.InnerText);
                    }
                }
               
            }

            return Task.FromResult(text.ToString());
        }
    }
}

