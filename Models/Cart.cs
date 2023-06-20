namespace DataGetter.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public decimal UserId { get; set; }
        public List<CartProduct> Products { get; set; }
    }
}
