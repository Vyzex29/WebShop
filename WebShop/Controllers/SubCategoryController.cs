using DataAccess.Context.Entity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryManager _subCategoryManager;
        private readonly ICategoryManager _categoryManager;

        public SubCategoryController(ISubCategoryManager subCategoryManager, ICategoryManager categoryManager)
        {
            _subCategoryManager = subCategoryManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            List<SubCategoryModel> categories = _subCategoryManager.GetAll()
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
            var categoryModel = new CreateSubCategoryModel
            {
                Categories = _categoryManager.GetAll()
            };
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult Create(CreateSubCategoryModel subcategory)
        {
            var userRole = HttpContext.Session.GetUserRole();
            if (userRole == null || userRole == Role.Regular.ToString())
            {
                return RedirectToAction("SignIn", "User");
            }
            ModelState.Remove(nameof(subcategory.Categories));
            if (ModelState.IsValid)
            {
                var createdCategory = new SubCategory
                {
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId,
                };

                _subCategoryManager.Add(createdCategory);


                return RedirectToAction(nameof(Index));
            }
            return View(subcategory);
        }
    }
}
