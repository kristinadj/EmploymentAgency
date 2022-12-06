using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentServiceProvider.WebApi.Model
{
    [Table("SupportedPaymentTypeServices", Schema = "dbo")]
    public class SupportedPaymentTypeService
    {
        [Key]
        public int Id { get; set; }
        public int WebShopId { get; set; }
        public int PaymentTypeServiceId { get; set; }

        public WebShop WebShop { get; set; }
        public PaymentTypeService PaymentTypeService { get; set;}
    }
}
