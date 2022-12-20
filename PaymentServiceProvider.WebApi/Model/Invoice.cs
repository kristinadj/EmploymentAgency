using System.ComponentModel.DataAnnotations;

namespace PaymentServiceProvider.WebApi.Model
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int WebShopIssuedId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public int WebShopId { get; set; }
        public bool IsPaid { get; set; }
        public int? TransactionId { get; set; }

        public Currency Currency { get; set; }
        public WebShop WebShop { get; set; }
        public Transaction Transaction { get; set; }
    }
}
