

using Business.Abstract;
using Entities.Concreate.ViewModels;
using Entitites.Concrete;
using Entitites.Concrete.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CommerceListMVC.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult List()
        {
            List<CategoryListViewModel> categories = _categoryService.GetAll().Select(c => new CategoryListViewModel()
            {
                CategoryName = c.CategoryName,
                CategoryID = c.CategoryID,
            }).ToList();

            return View(categories);
        }
        public IActionResult Detail(int id)
        {
   
            List<CategoryDetailViewModel> products = _productService.GetListByCategory(id).Select(

                p => new CategoryDetailViewModel
                {
                    PhotoUrl = p.PhotoUrl,
                    ProductName = p.ProductName,
                }
                ).ToList();
        
            ViewBag.CategoryName = _categoryService.GetAll().Where(c => c.CategoryID == id).FirstOrDefault();

            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryCreateViewModel viewModel)
        {
            var data = _categoryService.GetSingleCategory(viewModel.CategoryName);
            if (data != null)
            {
                ViewBag.ErrorMessage = "Böyle bir kategori zaten mevcut";
                return View();

            }
       
                if (!ModelState.IsValid)
            {
                return View();
            }
                if(ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryName = viewModel.CategoryName,
                };
                _categoryService.Add(category);
                ViewBag.Successful = "Kategori oluşturuldu";
                
            }

            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult CategoryControl()
        {
            List<CategoryListDetailedViewModel> model = _categoryService.GetAll().Select(x=>new CategoryListDetailedViewModel {
            
              CategoryID= x.CategoryID,
              CategoryName= x.CategoryName, 
            }).ToList();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int CategoryID)
        {
            var data = _categoryService.GetSingleCategory(CategoryID);
            

            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(int CategoryID, Category category)
        {
            var data = _categoryService.GetSingleCategory(CategoryID);
            data.CategoryName = category.CategoryName;
            _categoryService.Update(data);
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int CategoryID)
        {
            var data = _categoryService.GetSingleCategory(CategoryID);
            return View(data);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Delete(Category category)
        {

            var CategoryID = category.CategoryID;
            var category2 = _categoryService.GetSingleCategory(CategoryID);
            _categoryService.Delete(category2);
            return RedirectToAction("CategoryControl", "Category");
        }


    }
}

  
