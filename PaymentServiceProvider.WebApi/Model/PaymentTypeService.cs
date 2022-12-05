using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentServiceProvider.WebApi.Model
{
    [Table("PaymentServices", Schema = "dbo")]
    public class PaymentTypeService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Uri { get; set; }
        public bool IsActive { get; set; }
    }
}
