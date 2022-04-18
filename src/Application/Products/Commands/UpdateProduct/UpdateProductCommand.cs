using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public UpdateProductDto Dto { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var entity = await _context.Products.FindAsync(request.ProductId);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            entity.Name = dto.Name;
            entity.StatusId = dto.StatusId;
            entity.Stock = dto.Stock;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            await _context.SaveChangesAync(cancellationToken);
            return true;
        }
    }
}
