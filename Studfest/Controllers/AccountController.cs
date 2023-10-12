using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin;
using Studfest.Models;
using Studfest.Repository.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Studfest.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepo _accountRepo;
      
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(AccountRepo accountRepo, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepo = accountRepo;
           
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {

            try
            {
                if(signUp.Password.Trim() != signUp.ConfirmPassword.Trim())
                {
                    return View(signUp);
                }


               await _accountRepo.SignUp(signUp);
               ModelState.AddModelError("", "Verification email sent to you primary account email, check your email");
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(signUp);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {

            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }
            }catch (Exception ex)
            {

            }


            Login login = new Login();
            return View(login);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.RedirectToAction("LogOut", "Account");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                
                string feedback = await _accountRepo.Login(login, returnUrl); 
                if (!String.IsNullOrEmpty(returnUrl) &&  returnUrl != "Admin" || returnUrl != "User") 
                {
                     _httpContextAccessor.HttpContext.Session.SetString("Email", login.Email);
                    if(feedback == "Admin")
                    {
                        _httpContextAccessor.HttpContext.Session.SetString("AccessRight", "Admin");
                    }
                    if (feedback == "User")
                    {
                        _httpContextAccessor.HttpContext.Session.SetString("AccessRight", "User");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", returnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentails");
               
            }

            return View(login);


        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {   
            HttpContext.Session.Remove("AccessRight");
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Clear();
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", "Home");
        }
    }
}
