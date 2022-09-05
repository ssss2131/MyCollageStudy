using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTools.MemoCache
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private static void ValidateValueType<TResult>()
        {
            Type typeResult = typeof(TResult);
            if (typeResult.IsGenericType)
            {
                typeResult = typeResult.GetGenericTypeDefinition();
            }
            if (typeResult == typeof(IEnumerable<>) || typeResult == typeof(IAsyncEnumerable<>) ||
               typeResult == typeof(IAsyncEnumerable<TResult>) || typeResult == typeof(IQueryable) ||
               typeResult == typeof(IQueryable<TResult>))
                throw new InvalidOperationException("请使用List<T>或者T[]");
        }
        private static void Initial(ICacheEntry entry, int expireTime)
        {
            var time = Random.Shared.Next(expireTime, expireTime * 2);

            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(time);

        }
        public TResult? GetOrCreate<TResult>(string cacheKey, Func<ICacheEntry, TResult?> valueFactory, int expireSeconds = 60)
        {
            ValidateValueType<TResult>();
            if (!_memoryCache.TryGetValue(cacheKey, out TResult result))
            {
                using ICacheEntry entry = _memoryCache.CreateEntry(cacheKey);
                Initial(entry, expireSeconds);
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                result = valueFactory(entry);
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                entry.Value = result;
            }
            return result;
            throw new NotImplementedException();
        }

        public async Task<TResult?> GetOrCreateAsync<TResult>(string cacheKey, Func<ICacheEntry, Task<TResult?>> valueFactory, int expireSeconds = 60)
        {
            ValidateValueType<TResult>();
            if (!_memoryCache.TryGetValue(cacheKey, out TResult result))
            {
                using ICacheEntry entry = _memoryCache.CreateEntry(cacheKey);
                Initial(entry, expireSeconds);
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                result = await valueFactory(entry);
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                entry.Value = result;
            }
            return result;

        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
