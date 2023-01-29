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
    public class ProductCommerceListManager : IProductCommerceListService
    {
        private readonly IProductCommerceListDal _productCommerceListDal;

        public ProductCommerceListManager(IProductCommerceListDal productCommerceListDal)
        {
            _productCommerceListDal = productCommerceListDal;
        }
        public void Add(ProductCommerceList ProductCommerceList)
        {
            _productCommerceListDal.Add(ProductCommerceList);
        }

        public void Delete(ProductCommerceList ProductCommerceList)
        {
          _productCommerceListDal.Delete(ProductCommerceList);
        }

        public ICollection<ProductCommerceList> GetAll()
        {
           return _productCommerceListDal.GetAll();
        }

        public ICollection<ProductCommerceList> GetByCommerceListId(int id)
        {
          return _productCommerceListDal.GetAll(filter:x=>x.CommerceListID== id).ToList();
        }

        public ProductCommerceList GetById(int id)
        {
           return _productCommerceListDal.Get(filter:x=>x.CommerceListID==id);
        }

        public ProductCommerceList GetByIds(int id, int id2)
        {
            return _productCommerceListDal.GetAll(filter: x => x.CommerceListID == id).FirstOrDefault(x => x.ProductID == id2);
        }

        public void Update(ProductCommerceList ProductCommerceList)
        {
            _productCommerceListDal.Update(ProductCommerceList);
        }
    }
}
