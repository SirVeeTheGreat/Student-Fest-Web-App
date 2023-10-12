using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Controllers
{
    [Route("api/ProductApiController")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductApiController(IProduct product)
        {
            _product = product;

        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            var products = await _product.GetAllProducts();   
            return new JsonResult(products);    
        }



    }
}
