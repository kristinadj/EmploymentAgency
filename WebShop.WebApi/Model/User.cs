using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShopApp.WebApi.Util;

namespace WebShopApp.WebApi.Model
{
    [Table("Users", Schema = "dbo")]
    public class User : IdentityUser
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        public Role Role { get; set; }
        public bool IsPremiumAccount { get; set; }
        public int? ManagedCompanyId { get; set; }
        public int? AdminToWebShopId { get; set; }

        public Company ManagedCompany { get; set; }
        public WebShop WebShop { get; set; }
    }
}
