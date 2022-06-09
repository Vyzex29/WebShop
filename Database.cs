using WebShop.Models;

namespace WebShop
{
    public static class Database
    {
        public static CategoryModel electronics = new CategoryModel
        {
            Id = 1,
            Name = "Electronics",
            Products = new List<ProductModel>()
        };

        public static CategoryModel cars = new CategoryModel
        {
            Id = 2,
            Name = "Cars",
            Products = new List<ProductModel>()
        };

        public static ProductModel volvo = new ProductModel
        {
            Id = 1,
            Name = "Volvo",
            Description = "V70",
            Price = 5000,
            category = cars
        };

        public static ProductModel s20 = new ProductModel
        {
            Id = 2,
            Name = "Samsung",
            Description = "s20",
            Price = 500,
            category = electronics
        };

        public static ProductModel iphone = new ProductModel
        {
            Id = 3,
            Name = "Apple",
            Description = "11",
            Price = 500,
            category = electronics
        };

        public static List<CategoryModel> categoryModels = new List<CategoryModel> { electronics, cars };

        public static List<ProductModel> productModels = new List<ProductModel>
        {
            volvo,
            s20,
            iphone
        };
    }
}
