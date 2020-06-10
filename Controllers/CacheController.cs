using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace memcache.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CacheController : ControllerBase
  {
    [HttpGet]
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
  }
}