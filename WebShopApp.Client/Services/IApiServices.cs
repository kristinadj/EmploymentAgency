using EmploymentAgency.DTO.Shared;
using EmploymentAgency.DTO.WebShop;
using System.Text.Json;

namespace WebShopApp.Client.Services
{
    public interface IApiServices
    {
        Task<WebShopDTO> GetParentWebShopAsync();
        Task<List<PaymentTypeServiceDTO>> GetPaymentTypeServicesAsync(int webShopId);
        Task<List<SubscriptionPlanDTO>> GetSubscriptionPlansAsync();
    }

    public class ApiServices : IApiServices
    {
        private readonly HttpClient _httpClient;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WebShopDTO> GetParentWebShopAsync()
        {
            var response = await _httpClient.GetAsync("api/WebShop/ParentWebShop");
            if (!response.IsSuccessStatusCode)
                return null;

            var webShop = JsonSerializer.Deserialize<WebShopDTO>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return webShop;
        }

        public async Task<List<PaymentTypeServiceDTO>> GetPaymentTypeServicesAsync(int webShopId)
        {
            var response = await _httpClient.GetAsync(string.Format("api/PaymentServiceProvider/SupportedPaymentTypes/{0}", webShopId));
            if (!response.IsSuccessStatusCode)
                return null;

            var supportedPaymentTypes = JsonSerializer.Deserialize<List<PaymentTypeServiceDTO>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return supportedPaymentTypes;
        }

        public async Task<List<SubscriptionPlanDTO>> GetSubscriptionPlansAsync()
        {
            var response = await _httpClient.GetAsync("api/SubscriptionPlanss");
            if (!response.IsSuccessStatusCode)
                return null;

            var subscriptionPlans = JsonSerializer.Deserialize<List<SubscriptionPlanDTO>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return subscriptionPlans;
        }
    }
}
