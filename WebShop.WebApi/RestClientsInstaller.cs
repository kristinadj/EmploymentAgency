using WebShopApp.WebApi.Clients;

namespace WebShopApp.WebApi
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
