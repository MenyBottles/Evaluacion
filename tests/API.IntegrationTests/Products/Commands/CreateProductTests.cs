using API.IntegrationTests.Common.Helpers;
using Application.Products.Commands.CreateProduct;
using Domain.Common.Enums;
using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Products.Commands
{
    using static Testing;
    public class CreateProductTests
    {
        [Fact]
        public async Task ShouldCrateProduct()
        {

            var command = new CreateProductCommand
            {
                Dto = new CreateProductDto
                {
                    Name = "New name",
                    StatusId = 0,
                    Description = "New description",
                    Price = 10.00m,
                    Stock = 2
                }
            };
            var productId = await SendAsync(command);

            var item = await FindAsync<Product>(productId);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Dto.Name);
            item.StatusId.Should().Be((StatusId)command.Dto.StatusId);
            item.Description.Should().Be(command.Dto.Description);
            item.Price.Should().Be(command.Dto.Price);
            item.Stock.Should().Be(command.Dto.Stock);
        }
    }
}
