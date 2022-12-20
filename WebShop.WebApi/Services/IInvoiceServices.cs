using AutoMapper;
using EmploymentAgency.DTO.WebShop;
using WebShopApp.WebApi.Model;

namespace WebShopApp.WebApi.Services
{
    public interface IInvoiceServices
    {
        Task<Invoice> CreateInvoiceAsync(InvoiceDTO webShopInvoiceDTO);
    }

    public class InvoiceServices : IInvoiceServices
    {
        private readonly WebShopContext _context;
        private readonly IMapper _mapper;

        public InvoiceServices(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Invoice> CreateInvoiceAsync(InvoiceDTO webShopInvoiceDTO)
        {
            var invoice = _mapper.Map<Invoice>(webShopInvoiceDTO);
            invoice.IsPaid = false;
            invoice.Timestamp = DateTime.UtcNow;

            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }
    }
}
