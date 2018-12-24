using CurrencyConverter.Domain.Models.Requests;
using CurrencyConverter.Domain.Models.Responses;

namespace CurrencyConverter.Domain.Interfaces
{

    public interface IExchangeService
    {
        ListResponse GetSupportedCurrencies();
        RatesResponse GetExchange(RatesRequest request);
    }

}
