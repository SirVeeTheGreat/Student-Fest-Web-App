using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Controllers
{


    [Authorize]
    public class VendorController : Controller
    {

        private readonly IVendor _vendor;

        public VendorController(IVendor vendor)
        {
            _vendor = vendor;
        }

        public async Task<IActionResult> Index()
        {
            List<Vendor> vendors = new List<Vendor>();
            vendors = (List<Vendor>)await _vendor.GetVendors();

            return View(vendors);
        }

        [HttpGet]
        public IActionResult CreateVendor()
        {
            Vendor vendor = new Vendor();
            return View(vendor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor(Vendor vendor)
        {
            if(ModelState.IsValid)
            {
                await _vendor.Create(vendor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(vendor);
            }
           
        }
        


    }
}
