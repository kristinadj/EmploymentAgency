using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("Currencies", Schema = "dbo")]
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

        public ICollection<Service> Services { get; set; }
    }
}
