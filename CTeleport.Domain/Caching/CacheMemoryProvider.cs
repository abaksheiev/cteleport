using Microsoft.Extensions.Caching.Memory;

namespace CTeleport.Domain.Caching
{
    public class CacheMemoryProvider : ICacheProvider
    {
        /// <summary>
        /// Each time the object is updated.
        /// </summary>
        private readonly int CachTimeMinutes = 5;

        private readonly IMemoryCache memoryCache;

        public CacheMemoryProvider(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public T Get<T>(string cachKey)
        {
            if (memoryCache.TryGetValue(cachKey, out T? cacheValue))
            {
                return cacheValue;
            }

            return default;
        }

        public void Set<T>(string cachKey, T instance)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(CachTimeMinutes));

            memoryCache.Set(cachKey, instance, cacheEntryOptions);
        }
    }
}
