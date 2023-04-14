using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MathAPI.Controllers
{
    [Authorize]
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
                url = "http://10.0.131.233/Add" + queryStr;
            }
            else
            {
                url = "http://10.0.195.7/subtract" + queryStr; ;
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
