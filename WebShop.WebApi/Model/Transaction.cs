using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopApp.WebApi.Model
{
    [Table("Transactions", Schema = "dbo")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
    }
}
