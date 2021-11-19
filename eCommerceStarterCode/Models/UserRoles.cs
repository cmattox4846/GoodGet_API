namespace eCommerceStarterCode.Models
{
<<<<<<< HEAD
    public class UserRoles
=======
    public partial class UserRoles
>>>>>>> f04284b18902349d144b0aea5c1af6b10662078b
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

    }
}
