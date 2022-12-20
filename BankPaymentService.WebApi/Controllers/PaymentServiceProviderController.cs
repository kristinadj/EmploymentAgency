using BankPaymentService.WebApi.Clients;
using EmploymentAgency.DTO;
using EmploymentAgency.DTO.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BankPaymentService.WebApi.Controllers
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
                var dto = new PaymentTypeServiceDTO
                {
                    Name = _configuration["Eureka:Instance:AppName"],
                    Uri = _configuration["PaymentServiceUri"],
                    IsActive = true
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
