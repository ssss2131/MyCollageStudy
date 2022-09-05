using Microsoft.Extensions.Logging;
using StoreEfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class BaseImp<T> : IBase<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public BaseImp(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Delete(int key)
        {
            var entity = _appDbContext.Set<T>().Find(key);
            if (entity != null)
            {
                _appDbContext.Remove(entity);
                var res = _appDbContext.SaveChanges();
                if (res > 0)
                {     
                    return true;
                }              
            }
            return false;
        }

        public T Get(int key)
        {
            var entity =  _appDbContext.Set<T>().Find(key);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                Console.WriteLine("查询失败 未查询到记录");
                return null;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression)
        {
            if(expression!=null)
                return _appDbContext.Set<T>().AsQueryable().Where(expression);
            else
                return _appDbContext.Set<T>().AsQueryable();
        }

        public bool Insert(T t)
        {
            _appDbContext.Set<T>().Add(t);
            var res =  _appDbContext.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }

        public T QueryValue(Expression<Func<T, bool>>? expression)
        {
            if (expression!=null)
            {
#pragma warning disable CS8603 // 可能返回 null 引用。
                return _appDbContext.Set<T>().Where(expression).FirstOrDefault();
#pragma warning restore CS8603 // 可能返回 null 引用。
            }
#pragma warning disable CS8603 // 可能返回 null 引用。
            return _appDbContext.Set<T>().FirstOrDefault();
#pragma warning restore CS8603 // 可能返回 null 引用。

        }

        public T Update(T t)
        {
            _appDbContext.Set<T>().Update(t);
            var res = _appDbContext.SaveChanges();
            if (res > 0)
                return t;
            else
            {
                Console.WriteLine("更新失败");
                return null;
               
            }
               
        }   
    }
}
