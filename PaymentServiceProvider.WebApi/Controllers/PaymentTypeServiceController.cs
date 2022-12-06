using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Mvc;
using PaymentServiceProvider.WebApi.Clients;
using PaymentServiceProvider.WebApi.Services;

namespace PaymentServiceProvider.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTypeServiceController : ControllerBase
    {
        private readonly IPaymentTypeServices _paymentTypeServices;
        private readonly PaymentTypeServiceClient _paymentTypeServiceClient;

        public PaymentTypeServiceController(IPaymentTypeServices paymentTypeServices, PaymentTypeServiceClient paymentTypeServiceClient)
        {
            _paymentTypeServices = paymentTypeServices;
            _paymentTypeServiceClient = paymentTypeServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentTypeServiceDTO>>> GetAll()
        {
            var paymentServices = await _paymentTypeServices.GetAllAsync();
            return Ok(paymentServices);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<PaymentTypeServiceDTO>> GetById([FromRoute] int id)
        {
            var paymentService = await _paymentTypeServices.GetByIdAsync(id);
            if (paymentService == null) return NotFound();

            return Ok(paymentService);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<PaymentTypeServiceDTO>> AddPaymentService([FromBody] PaymentTypeServiceDTO paymentServiceDTO)
        {
            try
            {
                var paymentService = await _paymentTypeServices.AddAsync(paymentServiceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentTypeServiceDTO>> RemovePaymentService([FromRoute] int id)
        {
            try
            {
                var paymentService = await _paymentTypeServices.RemoveAsync(id);
                if (paymentService == null) return NotFound();

                return Ok(paymentService);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("TestConnection/{id}")]
        public async Task<ActionResult<string>> TestConnection([FromRoute] int id)
        {
            try
            {
                var paymentService = await _paymentTypeServices.GetByIdAsync(id);
                if (paymentService == null) return NotFound();

                _paymentTypeServiceClient.ConfigureHttpClient(paymentService.Uri);
                var response = await _paymentTypeServiceClient.TestConnectionAsync();

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
