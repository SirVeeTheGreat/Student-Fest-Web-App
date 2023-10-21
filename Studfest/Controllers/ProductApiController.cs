using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Controllers
{
    [Route("studentfest")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {

        private readonly IProduct _product;
        private readonly IService _service;
        public ProductApiController(IProduct product, IService service)
        {
            _product = product;
            _service = service;
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            var products = await _product.GetAllProducts();
            if (products == null)
            {
                return NotFound();
            }

            return new JsonResult(products);
        }


        [HttpGet]
        [Route("services")]
        public async Task<ActionResult<Services>> GetAllServices()
        {
            var services = await _service.GetAllServices();
            if (services == null)
            {
                return NotFound();
            }
            return new JsonResult(services);
        }

        [HttpGet("{userId}")]
        [Route("orders")]
        public async Task<ActionResult<Services>> GetOrders(int userId)
        {
            var services = await _service.GetAllServices();
            if (services == null)
            {
                return NotFound();
            }
            return new JsonResult(services);
        }

        [HttpGet]
        [Route("events")]
        public async Task<ActionResult<Services>> GetEvents()
        {
            var events = await _service.GetAllEvents();
            if (events == null)
            {
                return NotFound();
            }
            return new JsonResult(events);
        }


        [HttpPost]
        public ActionResult<Checkout> Checkout(Checkout checkout)
        {
             throw new NotImplementedException();
        }



    }
}
