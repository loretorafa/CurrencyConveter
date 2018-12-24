using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Models;

namespace CurrencyConverter.Test.Fakes
{
    public class ExchangeApiFake : IExchangeApi
    {
        public Quotes GetQuotes()
        {
            var quotes = new Quotes();

            quotes.USDBRL = 4;
            quotes.USDGBP = 0.8M;
            quotes.USDBTC = 0.00025M ;
            quotes.USDARS = 38;
            quotes.USDJPY = 110;

            return quotes; 
        }
    }
}
