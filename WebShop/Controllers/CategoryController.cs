using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WebShopDbContext _context;

        private readonly ICategoryManager _categoryManager;
        public CategoryController(WebShopDbContext context, ICategoryManager categoryManager)
        {
            _context = context;
            _categoryManager = categoryManager;
        }

        //adress.com/Category
        public IActionResult Index()
        {
           List <CategoryModel> categories = _categoryManager.GetAll()
                .Select(categoryFromDb => categoryFromDb.ToModel()).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoryModel = new CategoryModel
            {
                Products = new List<ProductModel>()
            };
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            ModelState.Remove(nameof(category.Products));
            if (ModelState.IsValid)
            {
                var createdCategory = new Category
                {
                    Name = category.Name
                };
                _categoryManager.Add(createdCategory);
                

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // adress.com/Category/View/{id} --> FIND ALL PRODUCTS UNDER A SPECIFIC CATEGORY
        public IActionResult View(int id)
        {
            var productViewModel = new ProductViewModel();
            using (_context)
            { 
                var selectedCategory = _context.Categories
                    .Include(c=>c.Products) // INCLUDE IS IMPRTANT to get the foreign key data
                    .FirstOrDefault(c => c.Id == id);

                if(selectedCategory is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    productViewModel.CategoryName = selectedCategory.Name;
                    
                    productViewModel.Products = selectedCategory.Products is not null?
                        selectedCategory.Products.Select(productFromDb =>
                    new ProductModel
                    {
                        Id = productFromDb.Id,
                        Name = productFromDb.Name,
                        Description = productFromDb.Description,
                        Price = productFromDb.Price,
                    }).ToList() : new List<ProductModel>();
                }
            }
               
            return View(productViewModel);
        }
    }
}
