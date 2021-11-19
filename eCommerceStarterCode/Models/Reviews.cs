namespace eCommerceStarterCode.Models
{
    public class Reviews
    {
        public string Review { get; set; }
        public int Rating { get; set; }
        public virtual Products Products { get; set; }

    }
}
