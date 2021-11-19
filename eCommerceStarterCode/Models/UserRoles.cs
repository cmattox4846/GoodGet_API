using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public partial class UserRoles
    {
        [Key]
        
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        
        [ForeignKey("User")]

        public int UserId { get; set; }

        public Products User { get; set; }

        [ForeignKey("Role")]

        public int RoleId { get; set; }

        public Products Role { get; set; }
    }
}
