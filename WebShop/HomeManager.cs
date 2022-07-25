using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop
{
    public class HomeManager
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;
        public HomeManager(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }


        public HomeViewModel GetHomeData(int selectedCategory = 1)
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            List<ProductModel> products = new List<ProductModel>();

            var catFromDb = _categoryManager.GetAll();
            foreach (var category in catFromDb)
            {
                categories.Add(category.ToModel());
            }
            var productsFromDb = _productManager.GetSpecificProducts(selectedCategory);

            foreach (var product in productsFromDb)
            {
                products.Add(product.ToModel());
            }

            var homeView = new HomeViewModel
            {
                categories = categories,
                products = products,
            };

            return homeView;
        }
    }
}

