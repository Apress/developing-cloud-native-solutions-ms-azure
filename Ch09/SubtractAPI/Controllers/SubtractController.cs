using Microsoft.AspNetCore.Mvc;

namespace SubtractAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubtractController : Controller
    {
        private readonly ILogger<SubtractController> _logger;

        public SubtractController(ILogger<SubtractController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Add(int a, int b)
        {
            _logger.LogInformation("Subtracting Two Numbers " + a + " and " + b);
            return a - b;
        }
    }
}
