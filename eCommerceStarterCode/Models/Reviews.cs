using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Reviews
    {
        [Key]

        public string Review { get; set; }
        public int Rating { get; set; }
        
        
        [ForeignKey("ProductReview")]

        public string ReviewID { get; set; }

        public ShoppingCart ProductReview { get; set; }
    }
}
