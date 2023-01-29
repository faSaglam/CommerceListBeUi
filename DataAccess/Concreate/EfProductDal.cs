
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
    //EfEntityRepository de <T Entity,T Context>  T Entity Product , T contex de CommerceListDbContext'i
    //alır ve yürürlüğe koyar (implement) IProduct dalı da implement eder
    //Gerçek hayatta şu örnek gibi düşünülebilir
    //tc vatandaşı hem tc anayasasına uymalı hem de uluslar arası ortaya konan insan hakları sözleşmesini uymalıdır.
    public class EfProductDal:EfEntityRepositoryFrameworkBase<Product,CommerceListDbContext>,IProductDal
    {
    }
}
