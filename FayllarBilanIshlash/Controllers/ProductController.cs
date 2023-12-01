using FayllarBilanIshlash.Data;
using FayllarBilanIshlash.DTOs;
using FayllarBilanIshlash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FayllarBilanIshlash.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public FileContentResult GetImage(int id)
        {
            ProductResponseDto product = _productService.GetProductWithImage(id);

            return File(product.Image, "image/png");
        }
        [HttpPost]
        public void CreateProduct([FromForm] ProductCommandDto productCommandDto)
        {
            _productService.CreateProduct(productCommandDto);
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }

    }
}
