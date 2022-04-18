using Application.Common.Interfaces;
using Application.Products.Queries.GetProduct;
using AutoMapper;
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
    public class CreateProductCommand : IRequest<GetProductDto>
    {
        public CreateProductDto Dto { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<CreateProductCommand, GetProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
            var result = _mapper.Map<GetProductDto>(entity);
            return result;
        }
    }
}
