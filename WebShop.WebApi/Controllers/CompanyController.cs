using AutoMapper;
using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Model;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CompanyController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterCompanyDTO registerCompanyDTO)
        {
            if (!registerCompanyDTO.Manager.Password.Equals(registerCompanyDTO.Manager.ConfirmPassword))
                return BadRequest("Passwords doesn't match");

            var user = _mapper.Map<User>(registerCompanyDTO.Manager);
            var result = await _userManager.CreateAsync(user, registerCompanyDTO.Manager.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // TODO: Reigster company

            return Ok();
        }
    }
}
