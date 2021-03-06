using Newtonsoft.Json;

namespace WebApiCurrency.Models
{
    public class Valute
    {
        [JsonProperty("ID")]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string CharCode { get; set; }
        public string NumCode { get; set; }
        public int Nominal { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }

    }
}
