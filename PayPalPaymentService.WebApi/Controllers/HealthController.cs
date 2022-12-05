using Microsoft.AspNetCore.Mvc;

namespace PayPalPaymentService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("PayPalPaymentService");
        }
    }
}
