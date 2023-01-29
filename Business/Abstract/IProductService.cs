
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        ICollection<Product> GetAll();
       
        Product GetById(int ProductID);

        Product GetProduct(string ProductName);
        ICollection<Product> GetListByCategory(int CategoryID);
        //List<Product> GetListByCommerceListId(int commerceListId);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
