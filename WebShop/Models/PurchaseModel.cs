namespace WebShop.Models
{
    public class PurchaseModel
    {
        public List<CartItemModel> CartItems { get; set; }

        public int TotalPrice { get; set; }
    }
}
