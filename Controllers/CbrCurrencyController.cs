using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiCurrency.IoC;
using WebApiCurrency.Models;

namespace WebApiCurrency.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CbrCurrencyController : ControllerBase
    {
        private readonly ICurrentCurrency _currency;
        public CbrCurrencyController(ICurrentCurrency currency)
        {
            _currency = currency;
        }

#nullable disable
        [HttpGet]
        [ActionName("currency")]
        public async Task<ActionResult<Valute>> GetCurrency(string id)
        {
            Valute item = (await _currency.GetCurrencies())
                                          .FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));

            if (item != null)
                return item;

            return NotFound();
        }
#nullable enable

        [HttpGet]
        [ActionName("currencies")]
        public async Task<ActionResult<IEnumerable<Valute>>> Currencies([FromQuery] CurrencyPageParameters @params)
        {
            if (@params.PageSize < 0)
                return BadRequest();

            var data = (await _currency.GetCurrencies()).Skip((@params.PageNumber - 1) * @params.PageSize).Take(@params.PageSize);

            if (data.Count() == 0)
                return BadRequest();

            return Ok(data);
        }
    }
}