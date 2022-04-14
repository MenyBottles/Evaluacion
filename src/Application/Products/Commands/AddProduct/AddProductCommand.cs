using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<Guid>
    {

    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            return new Guid();
        }
    }
}
