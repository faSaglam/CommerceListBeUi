

using Business.Abstract;
using DataAccess.Concreate;
using Entitites.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceListMVC.ViewComponents
{
    public class CategoryNavViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryNavViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<CategoryListViewModel> categoryList = _categoryService.GetAll().Select(c => new CategoryListViewModel()
            {
                CategoryName = c.CategoryName,
                CategoryID = c.CategoryID,
            }).ToList();
            return View(categoryList);

        }
    }
}
