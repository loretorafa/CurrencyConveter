using System;

namespace CurrencyConverter.Infrastructure.CrossCutting
{
    public static class ExchangeApiConfig
    {
        private const string BaseUrl = "http://apilayer.net/api/";
        private const string Endpoint = "live";

        public const string AccessKey = "079e77b7efe043575d1322eb75f8d1d4";
        public const string SupportedCurrencies = "BRL, GBP, BTC, ARS, JPY";
        public const string Format = "1";

        public static Uri Uri = new Uri(BaseUrl + Endpoint);
    }
}