using HelloRedis.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Repository
{
    public interface IBaseService<TEntity> where TEntity : class,new()
    {
      
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> QueryOne(Expression<Func<TEntity, bool>> expression);
        Task<bool> PutEnityAsync(TEntity entity);

        Task<bool> DeleteAsync(int Id);
        Task<bool> CreateAsync(TEntity entity);
        Task<List<TEntity>> QueryAsync();
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression);
    }
}
