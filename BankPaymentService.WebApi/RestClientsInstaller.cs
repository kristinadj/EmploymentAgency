using BankPaymentService.WebApi.Clients;

namespace BankPaymentService.WebApi
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
