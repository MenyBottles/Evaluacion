using Application.Common.Interfaces;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public CreateProductDto Dto { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var entity = new Product
            {
                Name = dto.Name,
                StatusId = (StatusId)dto.StatusId,
                Stock = dto.Stock,
                Description = dto.Description,
                Price = dto.Price
            };
            await _context.Products.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAync(cancellationToken);
            return entity.ProductId;
        }
    }
}
