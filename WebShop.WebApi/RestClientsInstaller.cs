using WebShop.WebApi.Clients;

namespace WebShop.WebApi
{
    public static class RestClientsInstaller
    {
        public static IServiceCollection AddPaymentServiceProviderRestClient(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPaymentServiceProviderClient), typeof(PaymentServiceProviderClient));
            return services;
        }
    }
}
