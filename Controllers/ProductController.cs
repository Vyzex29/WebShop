using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebShopDbContext _context;

        public ProductController(WebShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (_context)
            {
                products = _context.Products.Select(productFromDb => new ProductModel
                {
                    Id = productFromDb.Id,
                    Name = productFromDb.Name,
                    Description = productFromDb.Description,
                    Price = productFromDb.Price,
                    category = new CategoryModel
                    {
                        Id = productFromDb.Category.Id,
                        Name = productFromDb.Category.Name
                    }
                }).OrderBy(product => product.Name)
                .ToList();
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new CreateProductModel
            {
                Categories = _context.Categories.ToList(),
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel product)
        {
            ModelState.Remove(nameof(product.Categories));
            if (ModelState.IsValid)
            {
                var selectedCategory = _context.Categories.First(c => c.Id == product.CategoryId);
                var createdProduct = new Product
                {
                    Name = product.Name,
                    Description= product.Description,
                    Price = product.Price,
                    Category = selectedCategory
                };

                _context.Products.Add(createdProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public IActionResult View(int id)
        {
            var productModel = new ProductModel();
            using (_context)
            {
                var selectedProduct = _context.Products.Where(c => c.Id == id).FirstOrDefault();
                if (selectedProduct is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var category = _context.Products.Where(c => c.Id == id).Select(p => p.Category).First();
                    productModel.Id = selectedProduct.Id;
                    productModel.Name = selectedProduct.Name;
                    productModel.Description = selectedProduct.Description;
                    productModel.Price = selectedProduct.Price;
                    productModel.category = new CategoryModel
                    {
                        Name = category.Name
                    };
                    return View(productModel);
                }
            }
        }
    }
}
