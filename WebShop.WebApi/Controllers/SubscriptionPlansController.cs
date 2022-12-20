using EmploymentAgency.DTO.WebShop;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class SubscriptionPlansController : ControllerBase
    {
        private readonly ISubscriptionPlanServices _subscriptionPlanServices;

        public SubscriptionPlansController(ISubscriptionPlanServices subscriptionPlanServices)
        {
            _subscriptionPlanServices = subscriptionPlanServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionPlanDTO>>> GetSubscriptionPlans()
        {
            var subscriptionPackages = await _subscriptionPlanServices.GetSubscriptionPlansAsync();
            return Ok(subscriptionPackages);
        }
    }
}
