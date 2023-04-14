using System.ComponentModel.DataAnnotations;

namespace MyTextTranslator.Api.Models
{
    public class TranslatePayload
    {
        [Required]
        public string SourceLanguageCode { get; set; }
        [Required]
        public string TargetLanguageCode { get; set; }
        [Required]
        public string TextToBeTranslated { get; set; }
    }
}
