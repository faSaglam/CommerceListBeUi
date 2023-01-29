using Business.Abstract;
using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        ICollection<Category> ICategoryService.GetAll()
        {
           return _categoryDal.GetAll();
        }

        Category ICategoryService.GetSingleCategory(int id)
        {
            return _categoryDal.Get(filter:c=>c.CategoryID== id);
        }
        Category ICategoryService.GetSingleCategory(string id)
        {
            return _categoryDal.Get(filter: c => c.CategoryName == id);
        }
    }
}
