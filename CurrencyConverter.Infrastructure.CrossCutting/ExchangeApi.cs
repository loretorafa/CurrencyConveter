using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CurrencyConverter.Infrastructure.CrossCutting
{
    public class ExchangeApi : IExchangeApi
    {
        static HttpClient client = new HttpClient();


        public ExchangeApi()
        {
            client.BaseAddress = ExchangeApiConfig.Uri;
        }


        public Quotes GetQuotes()
        {

            var response = client.GetAsync("?access_key=" + ExchangeApiConfig.AccessKey + "&currencies=" + ExchangeApiConfig.SupportedCurrencies + "&format=" + ExchangeApiConfig.Format).Result;

            if (response.IsSuccessStatusCode)
            {
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                return JsonConvert.DeserializeObject<Quotes>(json["quotes"].ToString());
            }

            return null;
        }



    }

  
}
