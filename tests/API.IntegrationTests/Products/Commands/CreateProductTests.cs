
using API.IntegrationTests.Common;
using Application.Common.Exceptions;
using Application.Common.Mappings;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProduct;
using AutoMapper;
using Domain.Common.Enums;
using FluentAssertions;
using FluentValidation;
using Infraestructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ApplicationDbContextSeed = API.IntegrationTests.Common.ApplicationDbContextFixture;

namespace API.IntegrationTests.Products.Commands
{
    public class CreateProductTests : IClassFixture<ApplicationDbContextFixture>
    {
        private readonly IMapper _mapper;
        ApplicationDbContextFixture _fixture;

        public CreateProductTests(ApplicationDbContextSeed fixture)
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldRequireMinimunFields()
        {
            //Arrange
            var handler = new CreateProductCommandHandler(_fixture.context, _mapper);
            var dto = new CreateProductDto
            {
                Description = "Product Description",
                Price = 12.05m,
                StatusId = StatusId.Active,
                Stock = 2,
            };

            //Act
            //Assert

            await FluentActions.Invoking(() =>
                handler.Handle(new CreateProductCommand() { Dto = dto }, CancellationToken.None))
            .Should().NotThrowAsync<Application.Common.Exceptions.ValidationException>();

        }

        [Fact]
        public async Task ShouldCrateProduct()
        {

            //Arrange
            var dto = new CreateProductDto
            {
                Name = "Product Name",
                Description = "Product Description",
                Price = 12.05m,
                StatusId = StatusId.Active,
                Stock = 12,
            };
            var handler = new CreateProductCommandHandler(_fixture.context, _mapper);

            //Act

            var result = await handler.Handle(new CreateProductCommand() { Dto = dto }, CancellationToken.None);
            var entity = await _fixture.context.Products.FindAsync(result.ProductId);

            //Assert
            result.Should().BeOfType<GetProductDto>();
            entity.ProductId.Should().Be(result.ProductId);

        }
    }
}
