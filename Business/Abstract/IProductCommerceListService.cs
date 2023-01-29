using Entitites.Concrete;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductCommerceListService
    {

        ICollection<ProductCommerceList> GetAll();

        ICollection<ProductCommerceList> GetByCommerceListId(int id);
        ProductCommerceList GetByIds(int id , int id2);
        ProductCommerceList GetById(int id );
        void Add(ProductCommerceList ProductCommerceList);
        void Update(ProductCommerceList ProductCommerceList);
        void Delete(ProductCommerceList ProductCommerceList);
    }
}
