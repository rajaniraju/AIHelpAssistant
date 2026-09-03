using AISupport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AISupport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AIController : ControllerBase
    {
        private readonly IAIServices _aiService1;
        private readonly IAIServices _aiService2;

        public AIController(IAIServices aiService1, IAIServices aiService2)
        {
            _aiService1 = aiService1;
            
        }

        [HttpGet("ask")]
        public string Ask(string question)
        {
            return _aiService1.Ask(question, _aiService1.Id);
        }

        [HttpPost("answer")]
        public string answer(string answer)
        {
            return _aiService2.Answer(answer);
        }
    }   
}
