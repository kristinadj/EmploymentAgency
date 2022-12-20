using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Clients;

namespace WebShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class PaymentServiceProviderController : ControllerBase
    {
        private readonly IPaymentServiceProviderClient _paymentServiceProviderClient;
        private readonly IConfiguration _configuration;

        public PaymentServiceProviderController(IPaymentServiceProviderClient paymentServiceProviderClient, IConfiguration configuration)
        {
            _paymentServiceProviderClient = paymentServiceProviderClient;
            _configuration = configuration;
        }

        [HttpGet("Register")]
        public async Task<ActionResult> Register()
        {
            try
            {
                var dto = new WebShopDTO
                {
                    Name = _configuration["AppName"],
                    ParentWebShopId = null,
                    TransactionSuccessWebhook = _configuration["WeebhookUri:Success"],
                    TransactionFailureWebhook = _configuration["WeebhookUri:Failure"],
                    TransactionErrorWebhook = _configuration["WeebhookUri:Error"]
                };
                await _paymentServiceProviderClient.RegisterAsync(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("SupportedPaymentTypes/{webShopId}")]
        public async Task<ActionResult<List<PaymentTypeServiceDTO>>> GetSupportedPaymentTypes([FromRoute] int webShopId)
        {
            try
            {
                //var supportedPaymentTypes = await _paymentServiceProviderClient.GetSupportedPaymentTypesAsync(webShopId);
                var supportedPaymentTypes = new List<PaymentTypeServiceDTO>()
                {
                    new PaymentTypeServiceDTO
                    {
                        Id = 1,
                        Name = "Card Payment",
                        Uri = "http://BankPaymentService/api/Card/",
                        IsActive = true,
                    },
                    new PaymentTypeServiceDTO
                    {
                        Id = 1,
                        Name = "QR Code",
                        Uri = "",
                        IsActive = true,
                    },
                    new PaymentTypeServiceDTO
                    {
                        Id = 1,
                        Name = "PayPal",
                        Uri = "",
                        IsActive = true,
                    },
                    new PaymentTypeServiceDTO
                    {
                        Id = 1,
                        Name = "Bitcoin",
                        Uri = "",
                        IsActive = true,
                    }
                };
                return Ok(supportedPaymentTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}