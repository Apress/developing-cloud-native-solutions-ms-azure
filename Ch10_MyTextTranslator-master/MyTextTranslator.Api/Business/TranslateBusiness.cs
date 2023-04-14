using MyTextTranslator.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyTextTranslator.Api.Business
{
    public class TranslateBusiness : ITranslateBusiness
    {
        private string key;
        private string endpoint;
        private string location;
        public TranslateBusiness(IConfiguration configuration)
        {
            key = configuration.GetValue<String>("key");
            endpoint = configuration.GetValue<String>("endpoint");
            location = configuration.GetValue<String>("location");
        }
        public async Task<string> TranslateText(TranslatePayload translatePayload)
        {
            string route = $"/translate?api-version=3.0&from={translatePayload.SourceLanguageCode}&to={translatePayload.TargetLanguageCode}";
            object[] body = new object[] { new { Text = translatePayload.TextToBeTranslated } };
            var requestBody = JsonConvert.SerializeObject(body);
            string result = String.Empty;
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {

                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                result = await response.Content.ReadAsStringAsync();
                
            }
            return result;
    }
}
    }
