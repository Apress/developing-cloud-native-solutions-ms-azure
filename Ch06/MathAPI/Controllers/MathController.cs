using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MathAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : Controller
    {
        [HttpGet("Test")]
        public string Test()
        {
            return "Success";
        }
        [HttpGet("Get")]
        public string Get(string ops, int a,int b)
        {
            string result = "";
            string url = "";
            string queryStr = "?a=" + a + "&b=" + b;
            
            if (ops == "add")
            {
                url = "http://10.0.156.137/add" + queryStr;
            }
            else
            {
                url = "http://10.0.143.214/subtract" + queryStr; ;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
