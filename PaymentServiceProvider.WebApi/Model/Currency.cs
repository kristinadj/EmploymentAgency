using System.ComponentModel.DataAnnotations;

namespace PaymentServiceProvider.WebApi.Model
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
