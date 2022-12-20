namespace EmploymentAgency.DTO.PaymentServiceProvider
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int WebShopIssuedId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int WebShopId { get; set; }
        public bool IsPaid { get; set; }
        public int? TransactionId { get; set; }
    }
}
