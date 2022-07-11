namespace WebShop.Models
{
    public class CartModel
    {
        public int Id { get; set; }

        public List<CartItemModel> CartItems { get; set; }
    }
}
