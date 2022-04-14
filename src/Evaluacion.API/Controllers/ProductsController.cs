using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.API.Controllers
{
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetProductByIdAsync()
        {
            return Ok("All good");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync()
        {
            return Created("uri",1);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync()
        {
            return Ok("All Good.");
        }
    }
}
