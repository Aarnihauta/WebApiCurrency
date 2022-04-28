using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiCurrency.Models;

namespace WebApiCurrency.IoC
{
    public class CurrentCurrency : ICurrentCurrency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CurrentCurrency(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }
        public async Task<IEnumerable<Valute>> GetCurrencies()
        {
            var client = _httpClientFactory.CreateClient("currencyClient");
            var content = await client.GetAsync("daily_json.js");

            string json = await content.Content.ReadAsStringAsync();

            var obj = JObject.Parse(json)["Valute"].ToString();
            return JsonConvert.DeserializeObject<Dictionary<string, Valute>>(obj).Select(x => x.Value);
        }
    }
}
