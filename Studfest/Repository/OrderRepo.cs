using Microsoft.EntityFrameworkCore;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly StudentFestDb _context;

        public OrderRepo(StudentFestDb context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);    
            await _context.SaveChangesAsync();
            return order;
        }

       
        public async Task<Order> Details(string email)
        {
            return await _context.Orders
                .Include(i => i.OrderItems)
                .Include(a => a.User)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.User.Email == email);
        }
     

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders
                .Include(i => i.OrderItems)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
