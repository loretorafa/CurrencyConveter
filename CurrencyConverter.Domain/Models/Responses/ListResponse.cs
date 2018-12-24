using System.Collections.Generic;

namespace CurrencyConverter.Domain.Models.Responses
{
    public class ListResponse
    {
        public IList<Currency> Currencies { get; set; }
    }
}
