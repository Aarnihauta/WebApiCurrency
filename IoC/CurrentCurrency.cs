using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using WebApiCurrency.Models;

namespace WebApiCurrency.IoC
{
    public class CurrentCurrency : ICurrentCurrency
    {
        public async Task<IEnumerable<Valute>> GetCurrencies()
        {
            HttpClientHandler handler = new HttpClientHandler();

            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            handler.Proxy = proxy;

            var client = new HttpClient(handler);
            var content = await client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            string json = await content.Content.ReadAsStringAsync();

            var obj = JObject.Parse(json)["Valute"].ToString();
            return JsonConvert.DeserializeObject<Dictionary<string, Valute>>(obj).Select(x => x.Value);
        }
    }
}
