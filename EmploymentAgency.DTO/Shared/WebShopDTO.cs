namespace EmploymentAgency.DTO.Shared
{
    public class WebShopDTO
    {
        public int Id { get; set; }
        public int PaymentServiceProviderWebShopId { get; set; }
        public string Name { get; set; }
        public string TransactionSuccessWebhook { get; set; }
        public string TransactionFailureWebhook { get; set; }
        public string TransactionErrorWebhook { get; set; }
        public int? ParentWebShopId { get; set; }
    }
}
