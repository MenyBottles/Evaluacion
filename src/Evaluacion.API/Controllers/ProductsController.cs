using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {

        [HttpGet("{productId}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(Guid productId)
        {
            var product = await Mediator.Send(new GetProductQuery() { ProductId = productId });
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto dto)
        {
            var productId = await Mediator.Send(new CreateProductCommand() { Dto = dto });
            return CreatedAtRoute("GetProductById", new { productId = productId });
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(Guid productId, [FromBody] UpdateProductDto dto)
        {
            var result = await Mediator.Send(new UpdateProductCommand() { ProductId = productId, Dto = dto });
            if (result) return Ok();
            return BadRequest();
        }
    }
}
