using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("PurchasedSubscriptionPackages", Schema = "dbo")]
    public class PurchasedSubscriptionPlan
    {
        [Key]
        public int Id { get; set; }

        public int SubscriptionPackageId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Timestamp { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public Company Company { get; set; }
        
    }
}
