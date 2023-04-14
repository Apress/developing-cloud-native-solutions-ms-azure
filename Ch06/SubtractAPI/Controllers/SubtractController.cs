using Microsoft.AspNetCore.Mvc;

namespace SubtractAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubtractController : Controller
    {
        [HttpGet]
        public int Add(int a, int b)
        {
            return a - b;
        }
    }
}
