using Microsoft.Owin;
using Studfest.Models;

namespace Studfest.Repository.Account
{
    public interface IAccount
    {
        Task SignUp(SignUp signUp);

        Task<string> Login(Models.Login login);
    }
}
