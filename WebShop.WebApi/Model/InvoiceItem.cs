using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("InvoiceItems", Schema = "dbo")]
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }
        public Invoice Invoice { get; set; }
    }
}
