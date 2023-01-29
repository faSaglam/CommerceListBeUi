using Entitites.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{//Core DataAccess IEntityRepository sözleşmesi:
    //IEntityRepository<T> de T yeri product alır ve yürürlüğe koyar (implement)
    public interface IProductDal:IEntityReposityory<Product>
    {
       
    }
}
