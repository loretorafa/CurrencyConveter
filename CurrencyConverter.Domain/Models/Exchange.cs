using System;

namespace CurrencyConverter.Domain.Models
{
    public class Exchange
    {
        public Exchange(Currency currency, Decimal amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        public Currency Currency { get; set; }
        public Decimal Amount { get; set; }
    }
}
