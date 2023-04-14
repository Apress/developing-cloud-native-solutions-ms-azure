using MyTextTranslator.Api.Models;

namespace MyTextTranslator.Api.Business
{
    public interface ITranslateBusiness
    {
        Task<string> TranslateText(TranslatePayload translatePayload);
    }
}
