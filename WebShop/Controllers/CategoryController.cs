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
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            List <CategoryModel> categories = _categoryManager.GetAll()
                .Select(categoryFromDb => categoryFromDb.ToModel()).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            var categoryModel = new CategoryModel
            {
                SubCategories = new List<SubCategoryModel>()
            };
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            ModelState.Remove(nameof(category.SubCategories));
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
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            var productViewModel = new ProductViewModel();
            using (_context)
            { 
                var selectedCategory = _context.Categories
                    .Include(c=>c.SubCategories)
                    .ThenInclude(sb=>sb.Products)// INCLUDE IS IMPRTANT to get the foreign key data
                    .FirstOrDefault(c => c.Id == id);

                if(selectedCategory is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    productViewModel.CategoryName = selectedCategory.Name;
                    List<ProductModel> productModels = new List<ProductModel>();
                    var products = selectedCategory.SubCategories.SelectMany(sb => sb.Products);
                    foreach(var productFromDb in products)
                    {
                        productModels.Add(new ProductModel
                        {
                            Id = productFromDb.Id,
                            Name = productFromDb.Name,
                            Description = productFromDb.Description,
                            Price = productFromDb.Price,
                        });
                    }
                    productViewModel.Products = productModels;
                }
            }
               
            return View(productViewModel);
        }
    }
}
