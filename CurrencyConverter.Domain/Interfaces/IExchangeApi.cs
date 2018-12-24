using CurrencyConverter.Domain.Models;

namespace CurrencyConverter.Domain.Interfaces
{
    public interface IExchangeApi
    {
        Quotes GetQuotes();
    }
}
