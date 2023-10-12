using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;



namespace Studfest.App_Start
{
    public class Startup
    {
       
        public static void ConfigureAuth(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
                LogoutPath = new Microsoft.Owin.PathString("/Account/LogOut"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30)
            });


            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Authentication;
        }
    }

   
}
