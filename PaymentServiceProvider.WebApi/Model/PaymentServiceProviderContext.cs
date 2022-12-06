using Microsoft.EntityFrameworkCore;

namespace PaymentServiceProvider.WebApi.Model
{
    public class PaymentServiceProviderContext : DbContext
    {
        public DbSet<PaymentTypeService> PaymentServices { get; set; }
        public DbSet<WebShop> WebShops { get; set; }
        public DbSet<SupportedPaymentTypeService> SupportedPaymentTypeServices { get; set; }

        public PaymentServiceProviderContext(DbContextOptions<PaymentServiceProviderContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentTypeService>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<WebShop>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(x => x.ParentWebShopId).IsRequired(false);

                entity.HasOne(x => x.ParentWebShop)
                    .WithMany(x => x.SubWebShops)
                    .HasForeignKey(x => x.ParentWebShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SupportedPaymentTypeService>(entity =>
            {
                entity.HasIndex(x => new { x.WebShopId, x.PaymentTypeServiceId }).IsUnique();

                entity.HasOne(x => x.WebShop)
                    .WithMany(x => x.SupportedPaymentTypes)
                    .HasForeignKey(x => x.WebShopId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.PaymentTypeService)
                    .WithMany(x => x.SupportedPaymentTypes)
                    .HasForeignKey(x => x.PaymentTypeServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
