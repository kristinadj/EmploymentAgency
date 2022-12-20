using EmploymentAgency.DTO.PaymentServiceProvider;
using EmploymentAgency.DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using PaymentServiceProvider.WebApi.Services;

namespace PaymentServiceProvider.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _invoiceServices;
        private readonly IConfiguration _configuration;
        public InvoiceController(InvoiceServices invoiceServices, IConfiguration configuration)
        {
            _invoiceServices = invoiceServices;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<RedirectUriDTO>> CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            try
            {
                var invoice = await _invoiceServices.CreateInvoiceAsync(invoiceDTO);
                var redirectUri = new RedirectUriDTO
                {
                    Uri = _configuration["RedirectUri:Invoice"].Replace("@INVOICE_ID@", invoice.Id.ToString())
                };
                return Ok(redirectUri);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDTO>> GetById([FromRoute] int invoiceId)
        {
            var invoice = await _invoiceServices.GetByIdAsync(invoiceId);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpPost("Pay")]
        public async Task<ActionResult> PayInvoice([FromBody] PayInvoiceDTO payInvoiceDTO)
        {
            try
            {
                var invoice = await _invoiceServices.GetByIdAsync(payInvoiceDTO.InvoiceId);
                if (invoice == null)
                    return NotFound();

                var paymentInfo = await _pa

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
