using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CommerceListManager : ICommerceListService
    {
        private readonly ICommerceListDal _commerceListDal;

        public CommerceListManager(ICommerceListDal commerceLisyDal)
        {
            _commerceListDal = commerceLisyDal;
        }
        public void Add(CommerceList commerceList)
        {
            _commerceListDal.Add(commerceList);
        }

        public void Delete(CommerceList commerceList)
        {
            _commerceListDal.Delete(commerceList);
        }

        public ICollection<CommerceList> GetAll()
        {
            return _commerceListDal.GetAll();
        }

       
        public CommerceList GetById(int commerListId)
        {
           return _commerceListDal.Get(c=>c.CommerceListID == commerListId);
        }

        public ICollection<CommerceList> GetByUserId(string userId)
        {
            return _commerceListDal.GetAll(filter:c=>c.Id == userId);
        }

        public ICollection<CommerceList> GetWithProducts(int id)
        {
            return _commerceListDal.GetAll(x=>x.CommerceListID==id,x=>x.Products);
        }

        public void Update(CommerceList commerceList)
        {
            _commerceListDal.Update(commerceList);
        }

        ICollection<CommerceList> ICommerceListService.GetByUserId(string userId)
        {
            return _commerceListDal.GetAll(filter: x => x.Id == userId);
        }
    }
}
