using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<Product>
    {

    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IApplicationDbContext _context;

        public GetProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductQuery command, CancellationToken cancellationToken)
        {
            return new Product();
        }
    }
}
