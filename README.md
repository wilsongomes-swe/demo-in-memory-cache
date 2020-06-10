Steps:
- configure the memory cache on Services: ```services.AddMemoryCache();```
- Inject it with DI: ```[FromServices]IMemoryCache cache```
- Get the cached data or set it with GetOrCreate:
```
    public String Get([FromServices] IMemoryCache cache)
    {
      var date = cache.GetOrCreate("MyCacheKey", item =>
        {
          item.SlidingExpiration = TimeSpan.FromSeconds(1);
          // entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
          // entry.SetPriority(CacheItemPriority.High);
          return DateTime.Now;
        }
      );

      return date.ToLongTimeString();
    }
````
