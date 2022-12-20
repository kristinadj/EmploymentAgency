using EmploymentAgency.DTO.Shared;
using EmploymentAgency.DTO.WebShop;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.WebApi.Clients;
using WebShopApp.WebApi.Services;

namespace WebShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class InvoiceController : ControllerBase
    {
        private readonly IPaymentServiceProviderClient _paymentServiceProviderClient;
        private readonly IInvoiceServices _invoiceServices;
        private readonly IWebShopServices _webShopServices;

        public InvoiceController(IPaymentServiceProviderClient paymentServiceProviderClient, IInvoiceServices invoiceServices, IWebShopServices webShopServices)
        {
            _paymentServiceProviderClient = paymentServiceProviderClient;
            _invoiceServices = invoiceServices;
            _webShopServices = webShopServices;
        }

        [HttpPost]
        public async Task<ActionResult<RedirectUriDTO>> InvoiceForSubscriptionPlan([FromBody] InvoiceDTO webShopInvoiceDTO)
        {
            try
            {
                var pspWebShopId = await _webShopServices.GetPaymentServideProviderWebShopIdAsync(webShopInvoiceDTO.WebShopId);
                if (pspWebShopId == null)
                    return BadRequest("Web Shop is not registered to PaymentServiceProvider");

                var invoice = await _invoiceServices.CreateInvoiceAsync(webShopInvoiceDTO);

                var redirectUri = _paymentServiceProviderClient.CreateInvoiceAsync();
                return Ok(redirectUri);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
