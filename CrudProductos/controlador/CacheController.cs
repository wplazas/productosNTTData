using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

    [ApiController]
    [Route("api/[controller]")]
    public class CacheController
    {
        private readonly IDistributedCache _cache;

        public CacheController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string key)
        {
            var cachedData = await _cache.GetStringAsync(key);
            var message = $"Cached Value: {cachedData}";

            if (cachedData != null)
            {
                return (IActionResult)(message == null ? Results.NotFound() : Results.Ok(message));
            }

            // Si no está en caché, realiza alguna operación y almacena en caché
            var data = "Data to be cached";
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            await _cache.SetStringAsync(key, data, cacheOptions);

            return (IActionResult)(message == null ? Results.NotFound() : Results.Ok(message));
    }
    }

