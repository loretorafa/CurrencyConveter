using CurrencyConverter.Domain;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Models;
using CurrencyConverter.Domain.Models.Requests;
using CurrencyConverter.Domain.Models.Responses;
using System;

namespace CurrencyConverter.Services.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeApi _api;
        private readonly Quotes _quotes;

        public ExchangeService(IExchangeApi api)
        {
            _api = api;
            _quotes = api.GetQuotes();
        }

        public ListResponse GetSupportedCurrencies()
        {
            var response = new ListResponse();

            response.Currencies = SupportedCurrencies.Currencies;

            return response;
        }

        public RatesResponse GetExchange(RatesRequest request)
        {
            var response = new RatesResponse();

            var sourceCurrency = SupportedCurrencies.Currencies.Find(c => c.Code == request.From?.ToUpper());
            var targetCurrency = SupportedCurrencies.Currencies.Find(c => c.Code == request.To?.ToUpper());


            if (sourceCurrency != null && targetCurrency != null)
            {
                response.From = new Exchange(sourceCurrency, request.Amount);
                response.To = _quotes.GetExchanges(sourceCurrency, targetCurrency, request.Amount);

                return response;
            }

            throw new ApplicationException(string.Format("Conversão de {0} para {1} não suportada!", request.From, request.To));

        }


    }
}
