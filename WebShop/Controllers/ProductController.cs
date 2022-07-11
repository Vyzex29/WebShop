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
                    SubCategory = new SubCategoryModel
                    {
                        Id = productFromDb.Subcategory.Id,
                        Name = productFromDb.Subcategory.Name
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
                SubCategories = _context.SubCategories.ToList(),
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel product)
        {
            ModelState.Remove(nameof(product.SubCategories));
            ModelState.Remove(nameof(product.FilePath));
            ModelState.Remove(nameof(product.Image));
            if (ModelState.IsValid)
            {
                // getting file original name
                string FileName = product.Image.FileName;
                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;
                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photo", uniqueFileName);

                // copying file
                product.Image.CopyTo(new FileStream(imagePath, FileMode.Create));

                var selectedCategory = _context.SubCategories.First(c => c.Id == product.CategoryId);
                byte[] file;
                using (var ms = new MemoryStream())
                {
                    product.Image.CopyTo(ms);
                    file = ms.ToArray();
                }
                    var createdProduct = new Product
                {
                    Name = product.Name,
                    Description= product.Description,
                    Price = product.Price,
                    Subcategory = selectedCategory,
                    ImageName = uniqueFileName,
                    Image = file
                    };

                _context.Products.Add(createdProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            product.SubCategories =  _context.SubCategories.ToList();
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
                    var category = _context.Products.Where(c => c.Id == id).Select(p => p.Subcategory).First();
                    productModel.Id = selectedProduct.Id;
                    productModel.Name = selectedProduct.Name;
                    productModel.Description = selectedProduct.Description;
                    productModel.Price = selectedProduct.Price;
                    productModel.SubCategory = new SubCategoryModel
                    {
                        Name = category.Name
                    };
                    return View(productModel);
                }
            }
        }
    }
}
