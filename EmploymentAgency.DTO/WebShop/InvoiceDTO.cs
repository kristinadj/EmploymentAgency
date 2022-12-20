namespace EmploymentAgency.DTO.WebShop
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public int WebShopId { get; set; }
        public int IssuedToId { get; set; }
        public string IssuedToType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Timestamp { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; }
    }
}
