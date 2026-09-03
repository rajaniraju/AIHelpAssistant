

namespace AISupport.Services
{
    public class AIServices:IAIServices
    {  
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ask (string input, Guid serviceId1)
        {
            // Placeholder for AI response logic
            return $"Question: {input}, Service ID: {Id}";
        }
        public string Answer (string output) 
        {
            return $"my answer is:{output}";
        }
    }
}
