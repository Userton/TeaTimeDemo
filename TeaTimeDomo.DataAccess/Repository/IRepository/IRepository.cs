using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDomo.DataAccess.Repository.IRpository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter); // 加入這行
        void Add(T entity);
        void Update(T entity);
        void Remove (T entity) ;
        void RemoveRange(IEnumerable<T> entities);

    }
}