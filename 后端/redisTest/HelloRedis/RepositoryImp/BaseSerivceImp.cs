using HelloRedis.Domain;
using HelloRedis.Domain.Dto;
using HelloRedis.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloRedis.RepositoryImp
{
    public class BaseSerivceImp<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected readonly AbsDbcontext Npgcontext;
        //private readonly RedisHelper  RedisContext;
        private string? Message = null;
        public BaseSerivceImp(AbsDbcontext context/*,RedisHelper redis*/)
        {
            Npgcontext = context;
            //RedisContext = redis;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
         
            var res =  Npgcontext.Set<TEntity>().AddAsync(entity);
           
            if (await Npgcontext.SaveChangesAsync()> 0)
            {
                return true;
            }
            else
                return false;
           
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            var entity =await Npgcontext.Set<TEntity>().FindAsync(bookId);
            if (entity != null)
            {
                if (Npgcontext.Remove<TEntity>(entity) != null )
                {
                    await Npgcontext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
           
        }

        public async Task<TEntity> GetByIdAsync(int bookId)
        {
            var entity = await Npgcontext.Set<TEntity>().FindAsync(bookId);
            if (entity != null)
            { 
                return entity;
            }
            return null;
         
        }

        public async Task<bool> PutEnityAsync(TEntity entity)
        {
            Npgcontext.Entry<TEntity>(entity).State = EntityState.Modified;
            var res= await Npgcontext.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;          
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await Npgcontext.Set<TEntity>().ToListAsync();         
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Npgcontext.Set<TEntity>().Where(expression).ToListAsync() ;
            
        }

        public async Task<TEntity> QueryOne(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await Npgcontext.Set<TEntity>().Where(expression).FirstOrDefaultAsync();

            return entity;
        }
    }
}
