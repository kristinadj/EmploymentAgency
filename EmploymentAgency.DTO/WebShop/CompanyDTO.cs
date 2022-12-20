using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.DTO.WebShop
{
    public class CompanyDTO
    {
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

    }
}
