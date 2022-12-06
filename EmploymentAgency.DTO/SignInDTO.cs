using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.DTO
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
