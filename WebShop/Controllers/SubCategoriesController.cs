using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class SubCategoriesController : Controller
    {
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
    }
}
