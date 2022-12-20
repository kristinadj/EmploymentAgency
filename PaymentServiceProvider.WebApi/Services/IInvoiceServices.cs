using AutoMapper;
using EmploymentAgency.DTO.PaymentServiceProvider;
using Microsoft.EntityFrameworkCore;
using PaymentServiceProvider.WebApi.Model;

namespace PaymentServiceProvider.WebApi.Services
{
    public interface IInvoiceServices
    {
        Task<Invoice> CreateInvoiceAsync(InvoiceDTO invoiceDTO);
        Task<InvoiceDTO> GetByIdAsync(int invoiceId);
    }

    public class InvoiceServices : IInvoiceServices
    {
        private readonly PaymentServiceProviderContext _context;
        private readonly IMapper _mapper;
        public InvoiceServices(PaymentServiceProviderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Invoice> CreateInvoiceAsync(InvoiceDTO invoiceDTO)
        {
            var currency = await _context.Currencies
                .Where(c => c.Code == invoiceDTO.CurrencyCode)
                .AsNoTracking()
                .SingleOrDefaultAsync();
            if (currency == null) throw new Exception("Invalid CurrencyCode");

            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            invoice.Id = 0;
            invoice.IsPaid = false;
            invoice.CurrencyId = currency.Id;

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<InvoiceDTO> GetByIdAsync(int invoiceId)
        {
            return await _context.Invoices
                .Where(i => i.Id == invoiceId)
                .Select(i => _mapper.Map<InvoiceDTO>(i))
                .SingleOrDefaultAsync();
        }
    }
}
