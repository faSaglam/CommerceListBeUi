using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityReposityory<T> where T : class, IEntity, new()
    {
        //List<T> GetAll(Expression<Func<T, bool>> filter =null);
        //https://learn.microsoft.com/tr-tr/dotnet/api/system.linq.expressions.expression-1?view=net-7.0
        T Get(Expression<Func<T, bool>> filter ,params Expression<Func<T, object>>[] includes);

        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
      
        void Delete(T entity);

        void Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
