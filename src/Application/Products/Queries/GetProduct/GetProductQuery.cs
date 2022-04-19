using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

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
        private readonly ICacheService<Status> _cacheService;
        private readonly IDiscountService _discountService;

        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper, ICacheService<Status> cacheService, IDiscountService discountService)
        {
            _context = context;
            _mapper = mapper;
            _cacheService = cacheService;
            _discountService = discountService;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.SingleOrDefaultAsync(o => o.ProductId == request.ProductId);
            var status = await _cacheService.GetFromCache();
            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            entity.Status = status.SingleOrDefault(o => o.StatusId == entity.StatusId);
            //entity.Status = status.Find(o => o.StatusId == entity.StatusId);
            var result = _mapper.Map<GetProductDto>(entity);
            result.Discount = await _discountService.GetDiscountAsync();
            result.FinalPrice = Math.Round(result.Price * (100 - result.Discount) / 100,2);
            return result;
        }
    }
}
