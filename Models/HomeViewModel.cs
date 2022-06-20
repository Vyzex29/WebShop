namespace WebShop.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            categories = new List<CategoryModel>();
            products = new List<ProductModel>();
        }

        public List<CategoryModel> categories;

        public List<ProductModel> products;
    }
}
