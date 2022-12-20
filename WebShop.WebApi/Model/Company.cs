using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("Companies", Schema = "dbo")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string WebUrl { get; set; }

        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Industry { get; set; }

        public string ManagedByUserId { get; set; }

        [Required]
        public DateTime SubscriptionStartDate { get; set; }

        [Required]
        public DateTime SubscriptionEndData { get; set; }
        public bool IsActiveSubscription { get; set; }

        [Required, ForeignKey("ManagedByUserId")]
        public User ManagedByUser { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
        public ICollection<PurchasedService> PurchasedServices { get; set; }
        public ICollection<PurchasedSubscriptionPlan> PurchasedSubscriptionPlans { get; set; }
    }
}
