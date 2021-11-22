using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{

    

    public partial class UserRoles

    {
       
       
      
        [ForeignKey("User")]

        public string Id { get; set; }

        public User User { get; set; }

        [ForeignKey("Role")]

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
