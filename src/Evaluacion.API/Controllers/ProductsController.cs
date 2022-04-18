using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ActionName(nameof(GetProductByIdAsync))]
        [HttpGet("{productId}")]
        public async Task<GetProductDto> GetProductByIdAsync(Guid productId)
        {
            return await Mediator.Send(new GetProductQuery() { ProductId = productId });
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<GetProductDto>> CreateProductAsync([FromBody] CreateProductDto dto)
        {
            var product = await Mediator.Send(new CreateProductCommand() { Dto = dto });
            var createdAt = CreatedAtAction(nameof(GetProductByIdAsync),new { productId = product.ProductId }, product);
            return createdAt;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(Guid productId, [FromBody] UpdateProductDto dto)
        {
            var result = await Mediator.Send(new UpdateProductCommand() { ProductId = productId, Dto = dto });
            if (result) return Ok();
            return BadRequest();
        }
    }
}
