using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Reviews
    {
        [Key]


        public string Review { get; set; }
        public int Rating { get; set; }
        
        
        [ForeignKey("ProductId")]

        public int ReviewId { get; set; }

        public Products ProductId{ get; set; }
    }
}
