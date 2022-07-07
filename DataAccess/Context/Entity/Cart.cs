
namespace DataAccess.Context.Entity
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<CartItem> CartItems { get; set; }

        public bool IsPurchased { get; set; }

        public DateTime? PurchaseDate { get; set; }
    }
}
