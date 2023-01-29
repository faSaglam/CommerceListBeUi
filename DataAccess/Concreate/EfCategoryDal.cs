using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class EfCategoryDal : EfEntityRepositoryFrameworkBase<Category, CommerceListDbContext>, ICategoryDal
    {
      
    }
}
