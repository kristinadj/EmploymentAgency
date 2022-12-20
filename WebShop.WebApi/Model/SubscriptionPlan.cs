using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("SubscriptionPackages", Schema = "dbo")]
    public class SubscriptionPlan
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
        public int NumberOfMonths { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public bool IsActive { get; set; }

        public Currency Currency { get; set; }
        public ICollection<PurchasedSubscriptionPlan> PurchasedSubscriptionPlans { get; set; }
    }
}
