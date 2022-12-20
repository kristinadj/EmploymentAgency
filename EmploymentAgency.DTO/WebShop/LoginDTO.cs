using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.DTO.WebShop
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
