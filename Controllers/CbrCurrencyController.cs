using Microsoft.AspNetCore.Mvc;
using WebApiCurrency.IoC;
using WebApiCurrency.Models;

namespace WebApiCurrency.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CbrCurrencyController : ControllerBase
    {
        private ICurrentCurrency _currency;
        public CbrCurrencyController(ICurrentCurrency currency)
        {
            _currency = currency;
        }

        [HttpGet]
        [ActionName("currency")]
        public async Task<Valute> GetCurrency(string id)
        {
            var item = (await _currency.GetCurrencies()).FirstOrDefault(x => x.Id == id);
            return item;
        }

        [HttpGet]
        [ActionName("currencies")]
        public async Task<IEnumerable<Valute>> Currencies([FromQuery] CurrencyPageParameters @params)
        {
            if (@params.PageSize < 0)
                return Enumerable.Empty<Valute>();

            var data = (await _currency.GetCurrencies()).Skip((@params.PageNumber - 1) * @params.PageSize).Take(@params.PageSize);

            if(data.Count() == 0)
                return Enumerable.Empty<Valute>();

            return data;
        }
    }
}