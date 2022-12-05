using Polly;
using Polly.Retry;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace PaymentServiceProvider.WebApi.Clients
{
    public interface IPaymentTypeServiceClient
    {
        [Get("Health")]
        Task<string> TestConnectionAsync();
    }

    public class PaymentTypeServiceClient : IPaymentTypeServiceClient
    {
        private IPaymentTypeServiceClient _client;

        private readonly DiscoveryHttpClientHandler _handler;
        private static readonly AsyncRetryPolicy _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAtempt => TimeSpan.FromSeconds(3));

        public PaymentTypeServiceClient(IDiscoveryClient discoveryClient)
        {
            _handler = new DiscoveryHttpClientHandler(discoveryClient);
        }

        public void ConfigureHttpClient(string uri)
        {
            var httpClient = new HttpClient(_handler)
            {
                BaseAddress = new Uri(uri)
            };
            _client = RestClient.For<IPaymentTypeServiceClient>(httpClient);
        }

        public Task<string> TestConnectionAsync()
        {
            return _retryPolicy.ExecuteAsync(async () => await _client.TestConnectionAsync());
        }
    }
}
