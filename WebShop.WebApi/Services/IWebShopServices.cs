using AutoMapper;
using EmploymentAgency.DTO.Shared;
using Microsoft.EntityFrameworkCore;
using WebShopApp.WebApi.Model;

namespace WebShopApp.WebApi.Services
{
    public interface IWebShopServices
    {
        Task<WebShopDTO> GetParentWebShopAsync();
        Task UpdatePaymentServiceProviderWebShopId(int webShopId, int paymentServiceProviderWebShopId);
        Task<int?> GetPaymentServideProviderWebShopIdAsync(int webShopId);
    }

    public class WebShopServices : IWebShopServices
    {
        private readonly WebShopContext _context;
        private readonly IMapper _mapper;

        public WebShopServices(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WebShopDTO> GetParentWebShopAsync()
        {
            return await _context.WebShops
                .Where(e => e.ParentWebShopId == null && e.IsActive)
                .Select(e => _mapper.Map<WebShopDTO>(e))
                .SingleOrDefaultAsync();
        }

        public async Task<int?> GetPaymentServideProviderWebShopIdAsync(int webShopId)
        {
            return await _context.WebShops
                .Where(e => e.Id == webShopId && e.IsActive)
                .Select(e => e.PaymentServiceProviderWebShopId)
                .SingleOrDefaultAsync();
        }

        public async Task UpdatePaymentServiceProviderWebShopId(int webShopId, int paymentServiceProviderWebShopId)
        {
            var webShop = await _context.WebShops
                .Where(e => e.Id == webShopId && e.IsActive)
                .SingleOrDefaultAsync();
            webShop.PaymentServiceProviderWebShopId = paymentServiceProviderWebShopId;

            await _context.SaveChangesAsync();
        }
    }
}
