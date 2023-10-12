using Studfest.Models;

namespace Studfest.Interface
{
    public interface IVendor
    {

        Task<IEnumerable<Vendor>> GetVendors();
        Task<Vendor> Detail(int id);
        Task<Vendor> Create(Vendor vendor);
        Task<Vendor> Update(Vendor vendor);
        Task<Vendor> Delete(Vendor vendor);
    }
}
