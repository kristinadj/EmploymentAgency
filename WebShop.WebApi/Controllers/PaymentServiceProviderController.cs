using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Mvc;
using WebShop.WebApi.Clients;

namespace WebShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}