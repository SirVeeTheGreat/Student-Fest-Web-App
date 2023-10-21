using Studfest.Models;

namespace Studfest.Interface
{
    public interface IService
    {
        Task<IEnumerable<Services>> GetAllServices();    
        
        Task CreateService (Services services);

        Task<IEnumerable<Events>> GetAllEvents();

        Task<Events> EventDetails(int id);

        Task CreateEvent(Events events);

    }
}
