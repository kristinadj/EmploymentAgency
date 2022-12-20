using AutoMapper;
using EmploymentAgency.DTO.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class WebShopController : ControllerBase
    {
        private readonly IWebShopServices _webShopService;
        private readonly IMapper _mapper;

        public WebShopController(IWebShopServices webShopService, IMapper mapper)
        {
            _webShopService = webShopService;
            _mapper = mapper;
        }

        [HttpGet("ParentWebShop")]
        public async Task<ActionResult<WebShopDTO>> GetParentWebShop()
        {
            var webShop = await _webShopService.GetParentWebShopAsync();
            return Ok(webShop);
        }
    }
}
