using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTextTranslator.Api.Business;
using MyTextTranslator.Api.Models;

namespace MyTextTranslator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslateBusiness _translateBusiness;
        public TranslateController(ITranslateBusiness translateBusiness)
        {
            _translateBusiness = translateBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> GetTranslatedText(TranslatePayload translatePayload)
        {
            var translatedText = await _translateBusiness.TranslateText(translatePayload);
            if (String.IsNullOrEmpty(translatedText))
            {
                return BadRequest();
            }
            return Ok(new { result = translatedText});
        }
    }
}
