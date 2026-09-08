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
        private readonly IAIServices _aiService;
       

        public AIController(IAIServices aiService1, IAIServices aiService2)
        {
            _aiService = aiService1;
           
        }

        [HttpGet("ask")]
        public string Ask(string question)
        {
            return _aiService.Ask(question, _aiService.Id);
        }

        [HttpPost("answer")]
        public string answer(string answer)
        {
            return _aiService.Answer(answer);
        }
    }   
}
