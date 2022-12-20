using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("WebShops", Schema = "dbo")]
    public class WebShop
    {
        [Key]
        public int Id { get; set; }

        public int PaymentServiceProviderWebShopId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int? ParentWebShopId { get; set; }
        public bool IsActive { get; set; }
        public string AdminId { get; set; }
        public WebShop ParentWebShop { get; set; }

        [Required, ForeignKey("AdminId")]
        public User Admin { get; set; }
        public ICollection<WebShop> SubWebShops { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
