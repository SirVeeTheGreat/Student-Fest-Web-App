using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;
using System.Security.Claims;
using System.Web;


namespace Studfest.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService _service;
        private readonly IVendor _vendor;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IVendor vendor, IService service, ILogger<ServiceController> logger)
        {
            _vendor = vendor;
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index(IService service)
        {
            return View(await _service.GetAllServices());
        }


        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            Services service = new Services();
            var vendor = await _vendor.GetVendors();
            ViewBag.VendorItems = GetVendors(vendor);
            return View(service);
        }


        [HttpPost]
        public async Task<IActionResult> CreateService(Services services)
        {
            if(!ModelState.IsValid)
            {
                return View(services);
            }
            else
            {
                await _service.CreateService(services); 
                return RedirectToAction(nameof(Index)); 
            }
        }

        [HttpGet]
   
        public async Task<IActionResult> GetEvents()
        {
            return View(await _service.GetAllEvents());
        }

        [Authorize]
        [HttpGet]   
        public IActionResult CreateEvent()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClaims = (User as ClaimsPrincipal)?.Claims;

                if (userClaims != null)
                {

                    var emailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                    if (emailClaim != null)
                    {
                        string email = emailClaim.Value;

                        List<User> users = new List<User> 
                        {
                            new User
                            {
                                Email = email,
                            }
                        };
                        ViewBag.User = GetUser(users) ;
                    }
                }
            }

            return View(new Events());
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Events events, string email)
        {
            if (ModelState.IsValid)
            {
                events.UserEmail = email;
                _logger.LogInformation("Events Name: " + events.EventName + "\nEmail: " + email);
                await _service.CreateEvent(events);
                return RedirectToAction("Index" , "Product");
            }

            return View(events);
        }

        private List<SelectListItem> GetVendors(IEnumerable<Vendor> vendor)
        {
            var vendorList = new List<SelectListItem>();

            vendorList = vendor.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.VendorFirstName,
            }).ToList();

            return vendorList;
        }

        private List<SelectListItem> GetUser(List<User> user)
        {
            var vendorList = new List<SelectListItem>();

            vendorList = user.Select(i => new SelectListItem()
            {
                Value = i.Email,
                Text = i.Email,
            }).ToList();

            return vendorList;
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    return View(await _service.GetServiceById(id));

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Services services)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _service.UpateService(services);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return View(services);
        //    }
        //}




    }
}
