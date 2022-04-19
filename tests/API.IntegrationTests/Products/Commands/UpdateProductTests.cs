using API.IntegrationTests.Common;
using Application.Common.Exceptions;
using Application.Common.Mappings;
using Application.Products.Commands.UpdateProduct;
using AutoMapper;
using Domain.Common.Enums;
using FluentAssertions;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ApplicationDbContextFixture = API.IntegrationTests.Common.ApplicationDbContextFixture;

namespace API.IntegrationTests.Products.Commands;

public class UpdateProductTests : IClassFixture<ApplicationDbContextFixture>
{
    ApplicationDbContextFixture _fixture;

    public UpdateProductTests(ApplicationDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldUpdateProduct(){
        //Arrange
        await _fixture.SeedSampleDataAsync();
        var handler = new UpdateProductCommandHandler(_fixture.context);
        var product = await _fixture.context.Products.FirstOrDefaultAsync();
        var dto = new UpdateProductDto
        {
            Name = "Product Name",
            Description = "Product Description",
            Price = 12.05m,
            StatusId = StatusId.Active,
            Stock = 12,
        };

        //Act
        var result = await handler.Handle(new UpdateProductCommand() {ProductId = product.ProductId, Dto = dto }, CancellationToken.None);


        //Arrange
        result.Should().BeTrue();

    }

    [Fact]
    public async Task ShouldThrowNotFoundExceptionIfDoesntExist()
    {
        //Arrange
        var falseProductId = Guid.NewGuid();
        var handler = new UpdateProductCommandHandler(_fixture.context);

        //Act
        //Assert
        await FluentActions.Invoking(() =>
            handler.Handle(new UpdateProductCommand() { ProductId = falseProductId }, CancellationToken.None))
        .Should().ThrowAsync<NotFoundException>();

    }
}

