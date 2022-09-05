using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface IBase<T>
    {
        T Get(int key);
        IQueryable<T> GetAll(Expression<Func<T,bool>>? expression);
        bool Delete(int Key);
        bool Insert(T t);

        T Update(T t);

        T QueryValue(Expression<Func<T, bool>>? expression);
    }
}
