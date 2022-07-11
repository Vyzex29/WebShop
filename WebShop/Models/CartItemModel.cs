namespace WebShop.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
