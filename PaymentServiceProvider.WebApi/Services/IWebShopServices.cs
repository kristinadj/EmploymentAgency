using AutoMapper;
using EmploymentAgency.DTO;
using Microsoft.EntityFrameworkCore;
using PaymentServiceProvider.WebApi.Model;

namespace PaymentServiceProvider.WebApi.Services
{
    public interface IWebShopServices
    {
        public Task<WebShopDTO> RegisterAsync(WebShopDTO webShopDTO);
        public Task<WebShopDTO?> GetByIdAsync(int id);
        public Task<bool> AddPaymentTypeAsync(int webShopId, int paymentTypeServiceId);
        public Task<bool> RemovePaymentTypeAsync(int webShopId, int paymentTypeServiceId);

        public Task<List<PaymentTypeServiceDTO>> GetSupportedPaymentTypesAsync(int webShopId);
    }

    public class WebShopServices : IWebShopServices
    {
        private readonly PaymentServiceProviderContext _context;
        private readonly IMapper _mapper;

        public WebShopServices(PaymentServiceProviderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddPaymentTypeAsync(int webShopId, int paymentTypeServiceId)
        {
            var webShop = await _context.WebShops.FindAsync(webShopId);
            if (webShop == null) throw new Exception($"Invalid webShopId {webShopId}");

            var paymentTypeService = await _context.PaymentServices.FindAsync(paymentTypeServiceId);
            if (paymentTypeService == null) throw new Exception($"Invalid paymentTypeServiceId {paymentTypeServiceId}");

            var supporetdPaymentTypeService = new SupportedPaymentTypeService
            {
                WebShopId = webShop.Id,
                PaymentTypeServiceId = paymentTypeService.Id
            };

            _context.SupportedPaymentTypeServices.Add(supporetdPaymentTypeService);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<WebShopDTO?> GetByIdAsync(int id)
        {
            return await _context.WebShops
                .Where(e => e.Id == id && e.IsActive)
                .Select(e => _mapper.Map<WebShopDTO>(e))
                .SingleOrDefaultAsync();
        }

        public async Task<List<PaymentTypeServiceDTO>> GetSupportedPaymentTypesAsync(int webShopId)
        {
            return await _context.WebShops
                .Where(e => e.Id == webShopId && e.IsActive)
                .SelectMany(e => e.SupportedPaymentTypes.Where(p => p.PaymentTypeService.IsActive).Select(p => _mapper.Map<PaymentTypeServiceDTO>(p.PaymentTypeService)))
                .ToListAsync();
        }

        public async Task<WebShopDTO> RegisterAsync(WebShopDTO webShopDTO)
        {
            var webShop = _mapper.Map<WebShop>(webShopDTO);
            webShop.IsActive = true;

            _context.WebShops.Add(webShop);
            await _context.SaveChangesAsync();

            webShopDTO = _mapper.Map<WebShopDTO>(webShop);
            return webShopDTO;
        }

        public async Task<bool> RemovePaymentTypeAsync(int webShopId, int paymentTypeServiceId)
        {
            var supporetdPaymetnTypeService = await _context.SupportedPaymentTypeServices
                .Where(e => e.WebShopId == webShopId && e.PaymentTypeServiceId == paymentTypeServiceId)
                .SingleOrDefaultAsync();
            if (supporetdPaymetnTypeService == null) throw new Exception("Supporte Payment Type not found");

            _context.SupportedPaymentTypeServices.Remove(supporetdPaymetnTypeService);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
