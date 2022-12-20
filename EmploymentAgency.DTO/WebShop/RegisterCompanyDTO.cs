using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.DTO.WebShop
{
    public class RegisterCompanyDTO
    {
        public CompanyDTO Company { get; set; }
        public UserDTO Manager { get; set; }

        [Required]
        [Range(1, 12)]
        public int MonthsOfSubscription { get; set; }
    }
}
