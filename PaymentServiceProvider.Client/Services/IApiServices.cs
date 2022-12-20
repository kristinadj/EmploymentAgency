using EmploymentAgency.DTO.PaymentServiceProvider;
using EmploymentAgency.DTO.Shared;
using System.Text;
using System.Text.Json;

namespace PaymentServiceProvider.Client.Services
{
    public interface IApiServices
    {
        Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId);
        Task<List<PaymentTypeServiceDTO>> GetPaymentTypeServicesAsync(int webShopId);
        Task PayInvoiceAsync(PayInvoiceDTO payInvoiceDTO);
    }

    public class ApiServices : IApiServices
    {
        private readonly HttpClient _httpClient;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId)
        {
            var response = await _httpClient.GetAsync(String.Format("api/Invoice/{0}", invoiceId));
            if (!response.IsSuccessStatusCode)
                return null;

            var webShop = JsonSerializer.Deserialize<InvoiceDTO>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return webShop;
        }

        public async Task<List<PaymentTypeServiceDTO>> GetPaymentTypeServicesAsync(int webShopId)
        {
            var response = await _httpClient.GetAsync(string.Format("api/WebShop/SupportedPaymentTypes/{0}", webShopId));
            if (!response.IsSuccessStatusCode)
                return null;

            var supportedPaymentTypes = JsonSerializer.Deserialize<List<PaymentTypeServiceDTO>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return supportedPaymentTypes;
        }

        public async Task PayInvoiceAsync(PayInvoiceDTO payInvoiceDTO)
        {
            var content = JsonSerializer.Serialize(payInvoiceDTO);
            var response = await _httpClient.PostAsync("api/Invoice/Pay", new StringContent(content, Encoding.UTF8, "application/json"));
        }
    }
}
