
using AIHelpAssistantWebApplication.Interfaces;

namespace AIHelpAssistantWebApplication.Services
{
    public class DocumentExtractionService
    {
        private readonly PdfTextExtractor _pdfExtractor;
        private readonly WordTextExtractor _wordExtractor;
        private readonly ExcelTextExtractor _excelExtractor;
        private readonly PlainTextExtractor _plainTextExtractor;

        public DocumentExtractionService(
            PdfTextExtractor pdfExtractor,
            WordTextExtractor wordExtractor,
            ExcelTextExtractor excelExtractor,
            PlainTextExtractor plainTextExtractor)
        {
            _pdfExtractor = pdfExtractor;
            _wordExtractor = wordExtractor;
            _excelExtractor = excelExtractor;
            _plainTextExtractor = plainTextExtractor;
        }

        public Task<string> ExtractTextAsync(
            Stream stream,
            string fileExtension,
            CancellationToken cancellationToken = default)
        {
            return fileExtension.ToLowerInvariant() switch
            {
                ".pdf" => _pdfExtractor.ExtractTextAsync(stream, cancellationToken),

                ".docx" => _wordExtractor.ExtractTextAsync(stream, cancellationToken),

                ".xlsx" => _excelExtractor.ExtractTextAsync(stream, cancellationToken),

                ".txt" or ".csv" or ".md" =>
                    _plainTextExtractor.ExtractTextAsync(stream, cancellationToken),

                _ => throw new NotSupportedException(
                    $"File format '{fileExtension}' is not supported.")
            };
        }
    }
}
