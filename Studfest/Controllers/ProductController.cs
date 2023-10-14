using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly IVendor _vendor;
        public ProductController(IProduct product, IVendor vendor)
        {
            _product = product;
            _vendor = vendor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _product.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            Product product = new Product();
            var vendor = await _vendor.GetVendors();

            ViewBag.VendorItems = vendor.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.VendorFirstName 
            }).ToList();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
   
            
            await _product.Create(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
