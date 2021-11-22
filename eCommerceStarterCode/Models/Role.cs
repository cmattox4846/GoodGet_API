using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
       

       
    }
}
