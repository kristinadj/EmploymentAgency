using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Mvc;
using PaymentServiceProvider.WebApi.Services;

namespace PaymentServiceProvider.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebShopController : ControllerBase
    {
        private readonly IWebShopServices _webShopServices;

        public WebShopController(IWebShopServices webShopServices)
        {
            _webShopServices = webShopServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<WebShopDTO>> Register([FromBody] WebShopDTO webShopDTO)
        {
            try
            {
                var webShop = await _webShopServices.RegisterAsync(webShopDTO);
                return Ok(webShop);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<WebShopDTO>> GetById([FromRoute] int id)
        {
            var webShop = await _webShopServices.GetByIdAsync(id);
            if (webShop == null) return NotFound();

            return Ok(webShop);
        }

        [HttpGet("SupportedPaymentTypes/{webShopId}")]
        public async Task<ActionResult<List<PaymentTypeServiceDTO>>> GetSupportedPaymentTypes([FromRoute] int webShopId)
        {
            var webShop = await _webShopServices.GetByIdAsync(webShopId);
            if (webShop == null) return NotFound();

            var paymentTypes = await _webShopServices.GetSupportedPaymentTypesAsync(webShopId);
            return Ok(paymentTypes);
        }

        [HttpPost("PaymentType")]
        public async Task<ActionResult> AddPaymentType([FromQuery] int webShopId, [FromQuery] int paymentTypeServiceId)
        {
            try
            {
                await _webShopServices.AddPaymentTypeAsync(webShopId, paymentTypeServiceId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("PaymentType")]
        public async Task<ActionResult> RemovePaymentType([FromQuery] int webShopId, [FromQuery] int paymentTypeServiceId)
        {
            try
            {
                await _webShopServices.RemovePaymentTypeAsync(webShopId, paymentTypeServiceId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
