using Studfest.Models;

namespace Studfest.Interface
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrders();   
        Task<Order> Create(Order order);
        Task<Order> Details(string email);
    }
}
