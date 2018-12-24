using CurrencyConverter.Domain.Models;
using System.Collections.Generic;

namespace CurrencyConverter.Domain
{
    //This was added to reduce Complexity and Improve Performance of the External API
    public static class SupportedCurrencies
    {
        public static List<Currency> Currencies
        {
            get
            {
                List<Currency> list = new List<Currency>();

                list.Add(new Currency("BRL", "Brazilian Real"));
                list.Add(new Currency("USD", "United States Dollar"));
                list.Add(new Currency("GBP", "British Pound Sterling"));
                list.Add(new Currency("BTC", "Bitcoin"));
                list.Add(new Currency("ARS", "Argentine Peso"));
                list.Add(new Currency("JPY", "Japanese Yen"));

                return list;
            }
        }
    }
}
