using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project_Example.DataAccess.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetEntity(Expression<Func<T, bool>> exp);

        List<T> GetEntities(Expression<Func<T, bool>> exp);
    }
}
