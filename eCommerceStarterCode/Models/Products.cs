using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Products
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        
        //[ForeignKey("ShoppingCart")]
        
        //public string ShoppingCartId { get; set; }

        //public ShoppingCart ShoppingCart { get; set; }
    }
}
