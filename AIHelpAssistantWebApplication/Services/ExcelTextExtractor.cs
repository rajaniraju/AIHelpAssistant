using AIHelpAssistantWebApplication.Interfaces;
using ClosedXML.Excel;
using System.Text;

namespace AIHelpAssistantWebApplication.Services
    {
        public class ExcelTextExtractor : IDocumentTextExtractor
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

                using (var workbook = new XLWorkbook(stream))
                {
                    foreach (var worksheet in workbook.Worksheets)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        text.AppendLine($"Worksheet: {worksheet.Name}");

                        foreach (var row in worksheet.RowsUsed())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var rowValues = row.CellsUsed()
                                .Select(cell => cell.GetFormattedString());

                            text.AppendLine(string.Join(" | ", rowValues));
                        }
                    }
                }

                return Task.FromResult(text.ToString());
            }
        }
    }



