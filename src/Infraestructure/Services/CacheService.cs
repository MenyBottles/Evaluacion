using Application.Common.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class CacheService<T> : ICacheService<T> where T : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public CacheService(IApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<T>> GetFromCache()
        {
            var output = _memoryCache.Get<List<T>>(typeof(T).Name.ToLower());
            if (output == null)
            {
                output = new();
                output = await _context.Set<T>().ToListAsync();
                _memoryCache.Set(typeof(T).Name.ToLower(), output, TimeSpan.FromMinutes(5));
            }
            return output;
        }
    }
}
