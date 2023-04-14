using Microsoft.AspNetCore.Mvc;

namespace AddAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddController : Controller
    {
        [HttpGet]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
