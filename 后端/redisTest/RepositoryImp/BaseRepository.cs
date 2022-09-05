using HelloRedis.Repository;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Expressions;

namespace RepositoryImp
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>,IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(ISqlSugarClient context) : base(context)
        {
            base.Context = DbScoped.Sugar;
        }

        public Task<bool> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryAsync(int page, int size, ref int totalCount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}