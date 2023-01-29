using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommerceListService
    {
        ICollection<CommerceList> GetAll();
        ICollection<CommerceList> GetByUserId(string userId);

        //ICollection<CommerceList >GetAll(int commerceListId);
        ICollection<CommerceList> GetWithProducts(int id);
        CommerceList GetById(int commerListId);
        void Add(CommerceList commerceList);
        void Delete(CommerceList commerceList);
        void Update(CommerceList commerceList);
    }
}
