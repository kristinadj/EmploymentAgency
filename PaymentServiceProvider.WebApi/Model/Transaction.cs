using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentServiceProvider.WebApi.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public int PaymentServiceIssuedId { get; set; }
        public int InvoiceId { get; set; }
        public int PaymentServiceId { get; set; }
        public string Status { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; }

        [Required, ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public PaymentTypeService PaymentService { get; set; }
    }
}
