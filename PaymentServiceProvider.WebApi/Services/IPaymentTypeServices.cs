using AutoMapper;
using EmploymentAgency.DTO;
using Microsoft.EntityFrameworkCore;
using PaymentServiceProvider.WebApi.Model;

namespace PaymentServiceProvider.WebApi.Services
{
    public interface IPaymentTypeServices
    {
        public Task<List<PaymentTypeServiceDTO>> GetAllAsync();
        public Task<PaymentTypeServiceDTO?> GetByIdAsync(int id);
        public Task<PaymentTypeServiceDTO?> GetByNameAsync(string name);
        public Task<PaymentTypeServiceDTO> AddAsync(PaymentTypeServiceDTO paymentServiceDTO);
        public Task<PaymentTypeServiceDTO?> RemoveAsync(int id);
    }

    public class PaymentTypeServices : IPaymentTypeServices
    {
        private readonly PaymentServiceProviderContext _context;
        private readonly IMapper _mapper;

        public PaymentTypeServices(PaymentServiceProviderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentTypeServiceDTO> AddAsync(PaymentTypeServiceDTO paymentServiceDTO)
        {
            var paymentService = _mapper.Map<PaymentTypeService>(paymentServiceDTO);
            _context.PaymentServices.Add(paymentService);
            await _context.SaveChangesAsync();

            paymentServiceDTO = _mapper.Map<PaymentTypeServiceDTO>(paymentService);
            return paymentServiceDTO;
        }

        public async Task<List<PaymentTypeServiceDTO>> GetAllAsync()
        {
            return await _context.PaymentServices.Where(e => e.IsActive)
                .Select(e => _mapper.Map<PaymentTypeServiceDTO>(e))
                .ToListAsync();
        }

        public async Task<PaymentTypeServiceDTO?> GetByIdAsync(int id)
        {
            return await _context.PaymentServices
                .Where(e => e.Id == id && e.IsActive)
                .Select(e => _mapper.Map<PaymentTypeServiceDTO>(e))
                .SingleOrDefaultAsync();
        }

        public async Task<PaymentTypeServiceDTO?> GetByNameAsync(string name)
        {
            return await _context.PaymentServices
                .Where(e => e.Name == name && e.IsActive)
                .Select(e => _mapper.Map<PaymentTypeServiceDTO>(e))
                .SingleOrDefaultAsync();
        }

        public async Task<PaymentTypeServiceDTO?> RemoveAsync(int id)
        {
            var paymentService = await _context.PaymentServices.FindAsync(id);
            if (paymentService == null) return null;

            paymentService.IsActive = false;
            await _context.SaveChangesAsync();

            var paymentServiceDTO = _mapper.Map<PaymentTypeServiceDTO>(paymentService);
            return paymentServiceDTO;
        }
    }
}
