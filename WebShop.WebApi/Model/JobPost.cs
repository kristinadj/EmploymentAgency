using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShopApp.WebApi.Util;

namespace WebShopApp.WebApi.Model
{
    [Table("JobPosts", Schema = "dbo")]
    public class JobPost
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }
        public WorkingHours WorkingHours { get; set; }
        public SeniorityLevel SeniorityLevel { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public Company Company { get; set; }
    }
}
