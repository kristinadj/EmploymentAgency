using Microsoft.EntityFrameworkCore;

namespace PaymentServiceProvider.WebApi.Model
{
    public class PaymentServiceProviderContext : DbContext
    {
        public DbSet<PaymentTypeService> PaymentServices { get; set; }
        public PaymentServiceProviderContext(DbContextOptions<PaymentServiceProviderContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentTypeService>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });
        }
    }
}
