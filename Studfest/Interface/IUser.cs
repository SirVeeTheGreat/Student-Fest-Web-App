using Studfest.Models;

namespace Studfest.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();
        User Detail(int id);
        User Create(User product);
        User Update(User product);
        User Delete(User product);
    }
}
