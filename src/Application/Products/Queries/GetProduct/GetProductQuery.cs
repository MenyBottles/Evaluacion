using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.Include(o => o.Status).SingleOrDefaultAsync(o => o.ProductId == request.ProductId, cancellationToken);
            var result = _mapper.Map<GetProductDto>(entity);
            return result;
        }
    }
}
