using API.IntegrationTests.Common;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Products.Queries.GetProduct;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Products.Queries
{
    public class GetProductTests : IClassFixture<ApplicationDbContextFixture>
    {
        ApplicationDbContextFixture _fixture;
        private readonly IMapper _mapper;
        

        public GetProductTests(ApplicationDbContextFixture fixture)
        {
            _fixture = fixture;
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task ShouldGetProduct()
        {
            //Arrange
            await _fixture.SeedSampleDataAsync();
            var handler = GetHandler();
            var product = await _fixture.context.Products.FirstOrDefaultAsync();
            
            //Act
            var result = await handler.Handle(new GetProductQuery() { ProductId = product.ProductId }, CancellationToken.None);

            //Assert
            result.Should().BeOfType<GetProductDto>();
            result.Name.Should().Be(product.Name);
        }

        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfDoesntExist()
        {
            //Arrange
            var falseProductId = Guid.NewGuid();
            var handler = GetHandler();

            //Act
            //Assert
            await FluentActions.Invoking(() =>
                handler.Handle(new GetProductQuery() { ProductId = falseProductId }, CancellationToken.None))
            .Should().ThrowAsync<NotFoundException>();

        }

        public GetProductQueryHandler GetHandler()
        {

            var cacheService = new Mock<ICacheService<Status>>();
            var discountService = new Mock<IDiscountService>();
            var status = new List<Status>()
            {
                new Status()
                {
                    StatusId = Domain.Common.Enums.StatusId.Active,
                    Value = "Active"
                },
                new Status()
                {
                    StatusId = Domain.Common.Enums.StatusId.Inactive,
                    Value = "Inactive"
                }
            };
            cacheService.Setup(s => s.GetFromCache()).ReturnsAsync(status);
            discountService.Setup(s => s.GetDiscountAsync()).ReturnsAsync(35);
            return new GetProductQueryHandler(_fixture.context, _mapper, cacheService.Object, discountService.Object);
        }
    }
}
