using BankPaymentService.WebApi.Clients;
using Microsoft.AspNetCore.Mvc;

namespace BankPaymentService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IPaymentServiceProviderClient _paymentServiceProviderClient;

        public HealthController(IPaymentServiceProviderClient paymentServiceProviderClient)
        {
            _paymentServiceProviderClient = paymentServiceProviderClient;
        }

        [HttpGet("PSP")]
        public async Task<ActionResult<string>> TestPSPAsync()
        {
            var respone = await _paymentServiceProviderClient.TestConnectionAsync();
            return Ok(respone.ToString());
        }
    }
}
