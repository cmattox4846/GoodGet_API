namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Products Products { get; set; }
        public virtual User User { get; set; }


    }
}
