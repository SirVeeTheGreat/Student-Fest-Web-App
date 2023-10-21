using Microsoft.EntityFrameworkCore;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Repository
{
    public class ServiceRepo : IService
    {
        private readonly StudentFestDb _context;

        public ServiceRepo(StudentFestDb context)
        {
            _context = context;
        }

        public async Task CreateService(Services services)
        {
            await _context.Services.AddAsync(services); 
            await _context.SaveChangesAsync();
        }

        public async Task CreateEvent(Events events)
        {
             _context.Events.Add(events);
            await _context.SaveChangesAsync();
        }

        public async Task<Events> EventDetails(int id)
        {
            return await _context.Events
               .FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task<IEnumerable<Events>> GetAllEvents()
        {
            return await _context.Events
                 .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Services>> GetAllServices()
        {
            return await _context.Services.AsNoTracking().ToListAsync();
        }
    }
}
