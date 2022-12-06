using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("PurchasedServices", Schema = "dbo")]
    public class PurchasedService
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public int CompanyId { get; set; }

        public Service Service { get; set; }
        public Company Company { get; set; }
    }
}
