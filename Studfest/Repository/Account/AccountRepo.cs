using FireSharp.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Owin;
using Newtonsoft.Json;
using Studfest.Models;
using Studfest.Repository.DataConnection;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Studfest.Repository.Account
{
    public class AccountRepo : IAccount
    {
        private FireBaseConnect _connect;
        private Firebase.Auth.IFirebaseAuthProvider _authProvider;
        private IFirebaseClient _client;
        private ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountRepo(ILogger<AccountRepo> logger, IHttpContextAccessor httpContextAccessor)
        {

            _connect = new FireBaseConnect();
            _authProvider = _connect.authProvider;
            _client = _connect.firebaseClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task<string> Login(Login login, string returnUrl)
        {
            _logger.LogInformation($"Show - loggin in");
            bool isAdmin = false;
            var response = await _authProvider.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
            string token = response.FirebaseToken;

            var user = response.User;

            if (!String.IsNullOrEmpty(token))
            {
                var claims = new List<Claim>();

                try
                {
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.Authentication, token));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Set an expiration time
                    };

                    await _httpContextAccessor.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    isAdmin = this.IsAdmin(login);

                    if (isAdmin == false)
                    {
                        return "User";
                    }
                    else
                    {
                        return "Admin";
                    }
                }
                catch
                {
                    return "Authentication login failed";
                }
                 

            }
            else
            {
                return "Token null";
            }
        }

        private bool IsAdmin(Models.Login login)
        {
            bool isAdmin = false;
            var response = _client.Get("AccessRights");

            dynamic accessRightData = JsonConvert.DeserializeObject<dynamic>(response.Body);

            _logger.LogInformation($"Show - {accessRightData}");

            if (accessRightData != null)
            {
                foreach (var accessRightEmail in accessRightData)
                {
                    if (accessRightEmail.Value == login.Email)
                    {
                        isAdmin = true;
                        break; // Exit the loop since we found a match
                    }
                }
            }

            return isAdmin;
        }


        public async Task SignUp(SignUp signUp)
        {
            await _authProvider.CreateUserWithEmailAndPasswordAsync(signUp.Email, signUp.ConfirmPassword, signUp.Name, true);
        }
    }
}
