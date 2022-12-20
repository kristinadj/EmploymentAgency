using AutoMapper;
using EmploymentAgency.DTO.WebShop;
using Microsoft.EntityFrameworkCore;
using WebShopApp.WebApi.Model;

namespace WebShopApp.WebApi.Services
{
    public interface ISubscriptionPlanServices
    {
        Task<List<SubscriptionPlanDTO>> GetSubscriptionPlansAsync();
    }
    public class SubscriptionPlanServices : ISubscriptionPlanServices
    {
        private readonly WebShopContext _context;
        private readonly IMapper _mapper;

        public SubscriptionPlanServices(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SubscriptionPlanDTO>> GetSubscriptionPlansAsync()
        {
            return await _context.SubscriptionPlans
                .Where(x => x.IsActive)
                .Include(x => x.Currency)
                .Select(x => _mapper.Map<SubscriptionPlanDTO>(x))
                .ToListAsync();
        }
    }
}
