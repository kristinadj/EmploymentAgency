namespace EmploymentAgency.DTO
{
    public class SubscriptionPlanDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int NumberOfMonths { get; set; }
        public double Price { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
    }
}
