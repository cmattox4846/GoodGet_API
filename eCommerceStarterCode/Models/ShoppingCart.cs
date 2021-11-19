using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Quantity { get; set; }
        


        [ForeignKey("User")]

        public string UserID { get; set; }

        public ShoppingCart User { get; set; }

        [ForeignKey("Product")]

        public string ProductId { get; set; }

        public Products Product { get; set; }
    }
}
