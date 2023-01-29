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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal ;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
        public void Update(Product product)
        {
            _productDal.Update(product);
        }
        public ICollection<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int ProductID)
        {
           return _productDal.Get(filter:p=>p.ProductID == ProductID);
        }

        public ICollection<Product> GetListByCategory(int CategoryID)
        {
           return _productDal.GetAll(filter:p=>p.CategoryID == CategoryID).ToList();
        }

        public Product GetProduct(string ProductName)
        {
            
            return _productDal.Get(filter:p=>p.ProductName == ProductName);
        }
    }
}
