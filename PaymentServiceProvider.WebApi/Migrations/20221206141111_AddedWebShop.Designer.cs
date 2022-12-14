// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentServiceProvider.WebApi.Model;

#nullable disable

namespace PaymentServiceProvider.WebApi.Migrations
{
    [DbContext(typeof(PaymentServiceProviderContext))]
    [Migration("20221206141111_AddedWebShop")]
    partial class AddedWebShop
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.PaymentTypeService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PaymentTypeServices", "dbo");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.SupportedPaymentTypeService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentTypeServiceId")
                        .HasColumnType("int");

                    b.Property<int>("WebShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeServiceId");

                    b.HasIndex("WebShopId", "PaymentTypeServiceId")
                        .IsUnique();

                    b.ToTable("SupportedPaymentTypeServices", "dbo");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.WebShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ParentWebShopId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("TransactionErrorWebhook")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransactionFailureWebhook")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransactionSuccessWebhook")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentWebShopId");

                    b.ToTable("WebShops", "dbo");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.SupportedPaymentTypeService", b =>
                {
                    b.HasOne("PaymentServiceProvider.WebApi.Model.PaymentTypeService", "PaymentTypeService")
                        .WithMany("SupportedPaymentTypes")
                        .HasForeignKey("PaymentTypeServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PaymentServiceProvider.WebApi.Model.WebShop", "WebShop")
                        .WithMany("SupportedPaymentTypes")
                        .HasForeignKey("WebShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PaymentTypeService");

                    b.Navigation("WebShop");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.WebShop", b =>
                {
                    b.HasOne("PaymentServiceProvider.WebApi.Model.WebShop", "ParentWebShop")
                        .WithMany("SubWebShops")
                        .HasForeignKey("ParentWebShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentWebShop");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.PaymentTypeService", b =>
                {
                    b.Navigation("SupportedPaymentTypes");
                });

            modelBuilder.Entity("PaymentServiceProvider.WebApi.Model.WebShop", b =>
                {
                    b.Navigation("SubWebShops");

                    b.Navigation("SupportedPaymentTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
