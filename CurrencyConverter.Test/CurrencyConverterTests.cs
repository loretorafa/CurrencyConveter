using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Models.Requests;
using CurrencyConverter.Services.Services;
using CurrencyConverter.Test.Fakes;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CurrencyConverterTests
    {
        private IExchangeService _service;
        private IExchangeApi _fakeApi;

        public CurrencyConverterTests()
        {
            _fakeApi = new ExchangeApiFake();
            _service = new ExchangeService(_fakeApi);
        }


        [Test]
        public void Supported_Currencies_Greater_Than_Zero()
        {
            var response = _service.GetSupportedCurrencies();

            Assert.Greater(response.Currencies.Count, 0);
        }

        [Test]
        public void Null_Currencies_Throws_ApplicationException()
        {
            var request = new RatesRequest();

            Assert.Throws<ApplicationException>(() => _service.GetExchange(request));
        }

        [Test]
        public void Unsupported_Currencies_Throws_ApplicationException()
        {
            var request = new RatesRequest();
            request.From = "Foo";
            request.To = "Bar";

            Assert.Throws<ApplicationException>(() => _service.GetExchange(request));
        }

        [Test]
        public void Zero_Amount_Returns_Zero()
        {
            var request = new RatesRequest();
            request.From = "USD";
            request.To = "BRL";
            request.Amount = 0;
            var response = _service.GetExchange(request);

            Assert.AreEqual(0, response.To.Amount);
        }

        [Test]
        public void Negative_Amount_Returns_Negative()
        {
            var request = new RatesRequest();
            request.From = "USD";
            request.To = "BRL";
            request.Amount = -1;
            var response = _service.GetExchange(request);

            Assert.Negative(response.To.Amount);
        }

        [Test]
        public void BRL_To_USD_Returns_Four()
        {
            var request = new RatesRequest();
            request.From = "USD";
            request.To = "BRL";
            var response = _service.GetExchange(request);

            Assert.AreEqual(4, response.To.Amount);
        }

        [Test]
        public void USD_To_BRL_Returns_Quarter()
        {
            var request = new RatesRequest();
            request.From = "BRL";
            request.To = "USD";
            var response = _service.GetExchange(request);

            Assert.AreEqual(0.25, response.To.Amount);
        }
    }
}