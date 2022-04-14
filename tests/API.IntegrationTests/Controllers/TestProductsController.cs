using Evaluacion.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace API.IntegrationTests.Controllers
{
    public class TestProductsController
    {

        [Fact]
        public async Task Get_ReturnsStatusCode200_OnSuccess()
        {
            //Arrange
            var productsController = new ProductsController();
            //Act
            var result = (OkObjectResult)await productsController.GetProductByIdAsync();
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Create_ReturnsStatusCode201_OnSuccess()
        {

            //Arrange
            var productsController = new ProductsController();
            //Act
            var result = (CreatedResult)await productsController.CreateProductAsync();
            //Assert
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Update_ReturnsStatusCode200_OnSuccess()
        {

            //Arrange
            var productsController = new ProductsController();
            //Act
            var result = (OkObjectResult)await productsController.UpdateProductAsync();
            //Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
