
using System;
using System.Collections.Generic;
using System.Linq;




namespace AIHelpAssistantWebApplication.Services
{
    public class TextChunkingServices
    {
        private const int ChunkSize = 500;
        private const int ChunkOverlap = 50;
        public List<string> SplitIntoChunks(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            var words = text.Split(
                (char[])null,
                StringSplitOptions.RemoveEmptyEntries);

            var chunks = new List<string>();

            int startIndex = 0;

            while (startIndex < words.Length)
            {
                var chunkWords = words
                    .Skip(startIndex)
                    .Take(ChunkSize);

                var chunk = string.Join(" ", chunkWords);

                chunks.Add(chunk);

                startIndex += ChunkSize - ChunkOverlap;
            }

            return chunks;
        }
    }
}
