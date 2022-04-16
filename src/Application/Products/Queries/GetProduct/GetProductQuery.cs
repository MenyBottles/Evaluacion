using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public Guid ProductId { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var status = _memoryCache.Get<List<Status>>("status");
            if (status == null)
            {
                status = new();
                status = _context.Status.ToList();
                _memoryCache.Set("status", status, TimeSpan.FromMinutes(5));
            }

            entity.Status = status.Find(o => o.StatusId == entity.StatusId);
            var result = _mapper.Map<GetProductDto>(entity);
            return result;
        }
    }
}
