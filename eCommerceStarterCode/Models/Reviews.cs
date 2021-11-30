using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        public string Review { get; set; }
        public int Rating { get; set; }
        
        
        [ForeignKey("Product")]

        public int ProductId { get; set; }

        public Products Product{ get; set; }
    }
}
