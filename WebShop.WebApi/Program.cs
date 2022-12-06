using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using WebShop.WebApi;
using WebShop.WebApi.Model;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<WebShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddPaymentServiceProviderRestClient();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();


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
