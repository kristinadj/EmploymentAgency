﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopApp.WebApi.Model;

#nullable disable

namespace WebShopApp.WebApi.Migrations
{
    [DbContext(typeof(WebShopContext))]
    partial class WebShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActiveSubscription")
                        .HasColumnType("bit");

                    b.Property<string>("ManagedByUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("SubscriptionEndData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscriptionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ManagedByUserId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies", "dbo");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Currencies", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "EUR",
                            Name = "Euro"
                        },
                        new
                        {
                            Id = 2,
                            Code = "USD",
                            Name = "American Dollar"
                        },
                        new
                        {
                            Id = 3,
                            Code = "RSD",
                            Name = "Serbian Dinar"
                        });
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.JobPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SeniorityLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("WorkingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobPosts", "dbo");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.PurchasedService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PurchasedServices", "dbo");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.PurchasedSubscriptionPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionPackageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SubscriptionPackageId");

                    b.ToTable("PurchasedSubscriptionPackages", "dbo");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("WebShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("WebShopId");

                    b.ToTable("Services", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            CurrencyId = 1,
                            Description = "Service Package #1",
                            IsActive = true,
                            Price = 2.0,
                            WebShopId = 1
                        },
                        new
                        {
                            Id = 5,
                            CurrencyId = 1,
                            Description = "Service Package #2",
                            IsActive = true,
                            Price = 3.5,
                            WebShopId = 1
                        },
                        new
                        {
                            Id = 6,
                            CurrencyId = 1,
                            Description = "Service Package #3",
                            IsActive = true,
                            Price = 10.0,
                            WebShopId = 1
                        },
                        new
                        {
                            Id = 7,
                            CurrencyId = 1,
                            Description = "Service Package #4",
                            IsActive = true,
                            Price = 1.0,
                            WebShopId = 1
                        });
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.SubscriptionPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("SubscriptionPackages", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyId = 1,
                            Description = "Monthly Subscription",
                            IsActive = true,
                            NumberOfMonths = 1,
                            Price = 3.0
                        },
                        new
                        {
                            Id = 2,
                            CurrencyId = 1,
                            Description = "Monthly subscription for more than 6 months",
                            IsActive = true,
                            NumberOfMonths = 6,
                            Price = 2.0
                        },
                        new
                        {
                            Id = 3,
                            CurrencyId = 1,
                            Description = "Yearly subscription",
                            IsActive = true,
                            NumberOfMonths = 12,
                            Price = 30.0
                        });
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Transactions", "dbo");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AdminToWebShopId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsPremiumAccount")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ManagedCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "99116b2f-882a-4650-9914-86a44f9e6af7",
                            Email = "admin@webshop.com",
                            EmailConfirmed = false,
                            FirstName = "Joseph",
                            IsPremiumAccount = false,
                            LastName = "Weber",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@WEBSHOP.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJdUT5OObHd4whqWuzLI/04QiQkN/L4hs0aAqjjclqS+/A68YtW8LrCmh6wITegRUA==",
                            PhoneNumberConfirmed = false,
                            Role = 2,
                            SecurityStamp = "0fc639ee-ddb3-456e-90b1-fa6a37f121d4",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.WebShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ParentWebShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.HasIndex("ParentWebShopId");

                    b.ToTable("WebShops", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            IsActive = true,
                            Name = "Main Shop"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Company", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.User", "ManagedByUser")
                        .WithOne("ManagedCompany")
                        .HasForeignKey("WebShopApp.WebApi.Model.Company", "ManagedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagedByUser");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.JobPost", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.Company", "Company")
                        .WithMany("JobPosts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.PurchasedService", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.Company", "Company")
                        .WithMany("PurchasedServices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebShopApp.WebApi.Model.Service", "Service")
                        .WithMany("PurchasedServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.PurchasedSubscriptionPackage", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.Company", "Company")
                        .WithMany("PurchasedSubscriptionPackages")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebShopApp.WebApi.Model.SubscriptionPackage", "SubscriptionPackage")
                        .WithMany("PurchasedSubscriptionPackages")
                        .HasForeignKey("SubscriptionPackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("SubscriptionPackage");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Service", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.Currency", "Currency")
                        .WithMany("Services")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebShopApp.WebApi.Model.WebShop", "WebShop")
                        .WithMany("Services")
                        .HasForeignKey("WebShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("WebShop");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.SubscriptionPackage", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.Currency", "Currency")
                        .WithMany("SubscriptionPackages")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.WebShop", b =>
                {
                    b.HasOne("WebShopApp.WebApi.Model.User", "Admin")
                        .WithOne("WebShop")
                        .HasForeignKey("WebShopApp.WebApi.Model.WebShop", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShopApp.WebApi.Model.WebShop", "ParentWebShop")
                        .WithMany("SubWebShops")
                        .HasForeignKey("ParentWebShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("ParentWebShop");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Company", b =>
                {
                    b.Navigation("JobPosts");

                    b.Navigation("PurchasedServices");

                    b.Navigation("PurchasedSubscriptionPackages");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Currency", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("SubscriptionPackages");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.Service", b =>
                {
                    b.Navigation("PurchasedServices");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.SubscriptionPackage", b =>
                {
                    b.Navigation("PurchasedSubscriptionPackages");
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.User", b =>
                {
                    b.Navigation("ManagedCompany")
                        .IsRequired();

                    b.Navigation("WebShop")
                        .IsRequired();
                });

            modelBuilder.Entity("WebShopApp.WebApi.Model.WebShop", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("SubWebShops");
                });
#pragma warning restore 612, 618
        }
    }
}
