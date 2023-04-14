using Microsoft.AspNetCore.Mvc;

namespace AddAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddController : Controller
    {
        private readonly ILogger<AddController> _logger;

        public AddController(ILogger<AddController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Add(int a, int b)
        {
            _logger.LogInformation("Adding Two Numbers "+ a + " and "+b);
            return a + b;
        }
    }
}
