using Studfest.Models;

namespace Studfest.Interface
{
    public interface IOrder
    {
        IEnumerable<Order> GetOrders();

        Order GetOrder(int id); 

        Order Create(Order order);

        Order Delete(Order order);

        Order Details (int id);

        

    }
}
