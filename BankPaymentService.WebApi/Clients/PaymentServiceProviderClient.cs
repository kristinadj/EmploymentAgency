using EmploymentAgency.DTO;
using Polly;
using Polly.Retry;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace BankPaymentService.WebApi.Clients
{
    public interface IPaymentServiceProviderClient
    {
        [Get("Health")]
        Task<string> TestConnectionAsync();

        [Post("PaymentTypeService")]
        Task<PaymentTypeServiceDTO> RegisterAsync([Body] PaymentTypeServiceDTO paymentTypeServiceDTO);
    }

    public class PaymentServiceProviderClient : IPaymentServiceProviderClient
    {
        private readonly IPaymentServiceProviderClient _client;

        private static readonly AsyncRetryPolicy _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAtempt => TimeSpan.FromSeconds(3));

        public PaymentServiceProviderClient(IConfiguration configuration, IDiscoveryClient discoveryClient)
        {
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(configuration["PaymentServiceProviderUri"])
            };
            _client = RestClient.For<IPaymentServiceProviderClient>(httpClient);

        }

        public Task<string> TestConnectionAsync()
        {
            return _retryPolicy.ExecuteAsync(async () => await _client.TestConnectionAsync());
        }

        public Task<PaymentTypeServiceDTO> RegisterAsync(PaymentTypeServiceDTO paymentTypeServiceDTO)
        {
            return _retryPolicy.ExecuteAsync(async () => await _client.RegisterAsync(paymentTypeServiceDTO));
        }
    }
}
