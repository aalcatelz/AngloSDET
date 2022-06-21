namespace AngloSDET.TestAutomation.UI.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
        }
        public ICollection<Product> Products { get; set; }
        public decimal SubTotal { get; set; }
        public decimal FlatShippingRate { get; set; }
        public decimal Total { get; set; }
    }
}