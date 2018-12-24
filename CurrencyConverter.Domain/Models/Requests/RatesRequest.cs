using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Domain.Models.Requests
{
    public class RatesRequest
    {
        [Required]
        [StringLength(3,MinimumLength =3)]
        public string From { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string To { get; set; }
        public decimal Amount { get; set; } = 1;
    }
}
