﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("Services", Schema = "dbo")]
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WebShopId { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public bool IsActive { get; set; }
        public WebShop WebShop { get; set; }
        public Currency Currency { get; set; }
        public ICollection<PurchasedService> PurchasedServices { get; set; }
    }
}
