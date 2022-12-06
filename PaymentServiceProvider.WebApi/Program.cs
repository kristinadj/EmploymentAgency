using Microsoft.EntityFrameworkCore;
using PaymentServiceProvider.WebApi.Clients;
using PaymentServiceProvider.WebApi.Model;
using PaymentServiceProvider.WebApi.Services;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddDbContext<PaymentServiceProviderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Services
builder.Services.AddScoped<IPaymentTypeServices, PaymentTypeServices>();
builder.Services.AddScoped<IWebShopServices, WebShopServices>();
#endregion

#region Clients
builder.Services.AddScoped<PaymentTypeServiceClient>();
#endregion

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("api/Health");

app.Run();
