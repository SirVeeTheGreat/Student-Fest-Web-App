using Studfest.Models;

namespace Studfest.Interface
{
    public interface IDeliveryTeam
    {
        IEnumerable<DeliveryTeam> GetDeliveryTeam();
        DeliveryTeam Detail(int id);
        DeliveryTeam Create(User user);
        DeliveryTeam Update(User user);
        DeliveryTeam Delete(User user);
    }
}
