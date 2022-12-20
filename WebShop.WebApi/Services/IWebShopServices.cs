using AutoMapper;
using EmploymentAgency.DTO;
using Microsoft.EntityFrameworkCore;
using WebShopApp.WebApi.Model;

namespace WebShopApp.WebApi.Services
{
    public interface IWebShopServices
    {
        public Task<WebShopDTO> GetParentWebShopAsync();
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
    }
}
