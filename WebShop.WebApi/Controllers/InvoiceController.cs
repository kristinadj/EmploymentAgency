using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class InvoiceController : ControllerBase
    {
        [HttpPost("SubscriptionPlan")]
        public async Task<ActionResult> InvoiceForSubscriptionPlan()
        {
            return Ok();
        }
    }
}
