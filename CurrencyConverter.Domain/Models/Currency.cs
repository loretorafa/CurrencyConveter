namespace CurrencyConverter.Domain.Models
{
    public class Currency
    {

        public Currency(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public string Name { get; set; }
        
        public string Code { get; set; }
    }
}
