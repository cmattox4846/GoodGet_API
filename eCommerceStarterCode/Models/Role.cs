namespace eCommerceStarterCode.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual UserRoles UserRoles { get; set; }
    }
}
