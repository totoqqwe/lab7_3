using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class FunctionCache<TKey, TResult>
    {
        private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

        public delegate TResult FuncDelegate(TKey key);

        private class CacheItem
        {
            public TResult Result { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        public TResult Execute(FuncDelegate func, TKey key, TimeSpan cacheDuration)
        {
            if (cache.TryGetValue(key, out var cacheItem) && DateTime.Now < cacheItem.ExpirationTime)
            {
                return cacheItem.Result;
            }

            TResult result = func(key);

            cache[key] = new CacheItem
            {
                Result = result,
                ExpirationTime = DateTime.Now.Add(cacheDuration)
            };

            return result;
        }
    }
}
