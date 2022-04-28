using WebApiCurrency.Models;

namespace WebApiCurrency.IoC
{
    public interface ICurrentCurrency
    {
        Task<IEnumerable<Valute>> GetCurrencies();
    }
}
