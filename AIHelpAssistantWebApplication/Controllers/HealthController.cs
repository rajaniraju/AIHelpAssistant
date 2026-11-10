using Microsoft.AspNetCore.Mvc;

namespace AIHelpAssistantWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Status = "Healthy",
                Application = "AIHelpAssistant",
                Message = "AI Help Assistant API is running!"
            });
        }
    }
}
