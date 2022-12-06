using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShopApp.WebApi.Util;

namespace WebShopApp.WebApi.Model
{
    public class WebShopContext : IdentityUserContext<User>
    {
        public DbSet<WebShop> WebShops { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<PurchasedService> PurchasedServices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasIndex(x => x.Code).IsUnique();
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasOne(x => x.Company)
                    .WithMany(x => x.JobPosts)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchasedService>(entity =>
            {
                entity.HasOne(x => x.Service)
                    .WithMany(x => x.PurchasedServices)
                    .HasForeignKey(x => x.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Company)
                    .WithMany(x => x.PurchasedServices)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(x => new { x.Code, x.WebShopId }).IsUnique();

                entity.HasOne(x => x.WebShop)
                   .WithMany(x => x.Services)
                   .HasForeignKey(x => x.WebShopId)
                   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Currency)
                   .WithMany(x => x.Services)
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WebShop>(entity =>
            {
                entity.Property(x => x.ParentWebShopId).IsRequired(false);

                entity.HasOne(x => x.ParentWebShop)
                    .WithMany(x => x.SubWebShops)
                    .HasForeignKey(x => x.ParentWebShopId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(x => x.ManagedCompanyId).IsRequired(false);
                entity.Property(x => x.AdminToWebShopId).IsRequired(false);
            });

            #region Database Initialization
            modelBuilder.Entity<Currency>()
                .HasData(
                new Currency { Id = 1, Code = "EUR", Name = "Euro" },
                new Currency { Id = 2, Code = "USD", Name = "American Dollar" },
                new Currency { Id = 3, Code = "RSD", Name = "Serbian Dinar" }
            );

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = ADMIN_ID,
                FirstName = "Joseph",
                LastName = "Weber",
                Role = Role.WEB_SHOP_ADMIN,
                UserName = "MainWebShop-Admin",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                Email = "admin@webshop.com",
                IsPremiumAccount = false,
            });

            modelBuilder.Entity<WebShop>().HasData(new WebShop 
            { 
                Id = 1,
                Name = "Main Shop", 
                ParentWebShopId = null, 
                IsActive = true, 
                AdminId = ADMIN_ID
            });

            modelBuilder.Entity<Service>().HasData(
               new Service
               {
                    Id = 1,
                    WebShopId = 1,
                   Description = "Monthly Subscription",
                    Code = "M_SUB",
                    Price = 3,
                    CurrencyId = 1,
                    ShowToUser = false,
                },
                new Service
                {
                    Id = 2,
                    WebShopId = 1,
                    Description = "Monthly subscription for more than 6 months",
                    Code = "6M_SUB",
                    Price = 2,
                    CurrencyId = 1,
                    ShowToUser = false,
                },
                new Service
                {
                    Id = 3,
                    WebShopId = 1,
                    Description = "Yearly subscription",
                    Code = "12M_SUB",
                    Price = 30,
                    CurrencyId = 1,
                    ShowToUser = false,
                },
                new Service
                {
                    Id = 4,
                    WebShopId = 1,
                    Description = "Service Package #1",
                    Code = "S1",
                    Price = 2,
                    CurrencyId = 1,
                    ShowToUser = true
                },
                new Service
                {
                    Id = 5,
                    WebShopId = 1,
                    Description = "Service Package #2",
                    Code = "S2",
                    Price = 3.5,
                    CurrencyId = 1,
                    ShowToUser = true
                },
                new Service
                {
                    Id = 6,
                    WebShopId = 1,
                    Description = "Service Package #3",
                    Code = "S3",
                    Price = 10,
                    CurrencyId = 1,
                    ShowToUser = true
                },
                new Service
                {
                    Id = 7,
                    WebShopId = 1,
                    Description = "Service Package #4",
                    Code = "S4",
                    Price = 1,
                    CurrencyId = 1,
                    ShowToUser = true
                }
            );
            #endregion
        }
    }
}
