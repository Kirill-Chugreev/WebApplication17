using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace memory_caching_api
{
    public class DataService: IDataService
    {
        private readonly IMemoryCache _memoryCache;

        public DataService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string? Get(string key)
        {
            var found = _memoryCache.TryGetValue(key, out var value);
            return found ? value.ToString() : null;
        }


        public void Upsert(string key, string value)
        {
            try
            {
                var s = _memoryCache.Set(key, value);
            }
            catch (Exception ex)
            {
                
            }
        }

        
        public void Upsert(string key, string value, TimeSpan expiration)
        {
            try
            {
                var s = _memoryCache.Set(key, value, expiration);
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Delete(string key)
        {
            try
            {
                _memoryCache.Remove(key);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
    public interface IDataService
    {
        string? Get(string key);

   
        void Upsert(string key, string value);

        void Upsert(string key, string value, TimeSpan expiration);

        void Delete(string key);
    }
}
