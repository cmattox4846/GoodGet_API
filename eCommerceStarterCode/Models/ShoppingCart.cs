using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        


        [ForeignKey("User")]

        public string UserID { get; set; }

        public User User{ get; set; }

        [ForeignKey("Product")]

        public int ProductId { get; set; }

        public Products Product { get; set; }
    }
}
