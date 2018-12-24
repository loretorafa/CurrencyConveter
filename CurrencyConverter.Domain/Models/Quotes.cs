namespace CurrencyConverter.Domain.Models
{
    public class Quotes
    {
        public decimal USDUSD { get { return 1; } }
        public decimal USDBRL { get; set; }
        public decimal USDGBP { get; set; }
        public decimal USDBTC { get; set; }
        public decimal USDARS { get; set; }
        public decimal USDJPY { get; set; }

        public Exchange GetExchanges(Currency source, Currency target, decimal amount)
        {

            var sourceprop = this.GetType().GetProperty("USD" + source.Code);
            var sourceRate = (decimal)sourceprop.GetValue(this);

            var prop = this.GetType().GetProperty("USD" + target.Code);
            var currencyRate = (decimal)prop.GetValue(this);

            decimal targetAmount = 1 / sourceRate * currencyRate;

            return new Exchange(target, targetAmount * amount);
        }

    }

}
