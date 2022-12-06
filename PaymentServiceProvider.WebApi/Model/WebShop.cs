using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentServiceProvider.WebApi.Model
{
    [Table("WebShops", Schema = "dbo")]
    public class WebShop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionSuccessWebhook { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionFailureWebhook { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionErrorWebhook { get; set; }
        public Nullable<int> ParentWebShopId { get; set; }
        public bool IsActive { get; set; }

        public WebShop ParentWebShop { get; set; }
        public List<WebShop> SubWebShops { get; set; }
        public List<SupportedPaymentTypeService> SupportedPaymentTypes { get; set; }
    }
}
