using AutoMapper;
using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Model;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenCreationService _tokenCreationService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsersController(
            UserManager<User> userManager,
            ITokenCreationService tokenCreationService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenCreationService = tokenCreationService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody] UserDTO userDTO)
        {
            if (!userDTO.Password.Equals(userDTO.ConfirmPassword))
                return BadRequest("Passwords doesn't match");

            var user = _mapper.Map<User>(userDTO);
            user.Role = Util.Role.USER;
            user.IsPremiumAccount = false;

            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<LoginResultDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user == null)
                return BadRequest("Bad credentials");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isPasswordValid)
                return BadRequest("Bad credentials");

            var token = _tokenCreationService.CreateToken(user);
            return Ok(token);
        }
    }
}
