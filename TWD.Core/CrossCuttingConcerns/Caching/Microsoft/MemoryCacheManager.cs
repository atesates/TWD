using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using TWD.Core.Utilities.IoC;

namespace TWD.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _cache;
        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);//we will be controlled whether it returns value (deger dönüp dönmedigini kontrol etmis oluyoruz)
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)//there is no method in .net core to get cached lists, it is written manuel
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty(name:"EntriesCollection",bindingAttr: System.Reflection.BindingFlags.NonPublic 
                | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }
    }
}
