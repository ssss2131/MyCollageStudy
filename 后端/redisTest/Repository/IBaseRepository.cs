using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class,new()
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        //根据条件自定义查询
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func);
        //分页
        Task<List<TEntity>> QueryAsync(int page, int size, ref int totalCount);
        

    }
}
