using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShopApp.WebApi.Util;

namespace WebShopApp.WebApi.Model
{
    [Table("Invoice", Schema = "dbo")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public int WebShopId { get; set; }
        public int IssuedToId { get; set; }
        public IssuedToType IssuedToType { get; set;}
        public bool IsPaid { get; set; }
        public DateTime Timestamp { get; set; }

        public Currency Currency { get; set; }
        public WebShop WebShop { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
