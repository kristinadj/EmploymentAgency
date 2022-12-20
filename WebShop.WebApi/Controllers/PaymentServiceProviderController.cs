using EmploymentAgency.DTO;
using EmploymentAgency.DTO.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Clients;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class PaymentServiceProviderController : ControllerBase
    {
        private readonly IPaymentServiceProviderClient _paymentServiceProviderClient;
        private readonly IWebShopServices _webShopService;
        private readonly IConfiguration _configuration;

        public PaymentServiceProviderController(
            IPaymentServiceProviderClient paymentServiceProviderClient, 
            IWebShopServices webShopService, 
            IConfiguration configuration)
        {
            _paymentServiceProviderClient = paymentServiceProviderClient;
            _webShopService = webShopService;
            _configuration = configuration;
        }

        [HttpGet("Register")]
        public async Task<ActionResult> Register([FromRoute] int webShopId)
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
                var webShop = await _paymentServiceProviderClient.RegisterAsync(dto);
                await _webShopService.UpdatePaymentServiceProviderWebShopId(webShopId, webShop.PaymentServiceProviderWebShopId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("SupportedPaymentTypes/{webShopId}")]
        public ActionResult<List<PaymentTypeServiceDTO>> GetSupportedPaymentTypes([FromRoute] int webShopId)
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
                    /*
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
                    }*/
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