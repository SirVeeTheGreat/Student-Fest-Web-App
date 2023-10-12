using Microsoft.EntityFrameworkCore;
using Studfest.Data;
using Studfest.Interface;

namespace Studfest.Repository
{
   
    public class VendorRepo : IVendor
    {
        private readonly StudentFestDb _context;
        public VendorRepo(StudentFestDb context)
        {
            _context = context;
        }
        public async Task<Models.Vendor> Create(Models.Vendor vendor)
        {
            await _context.Vendor.AddAsync(vendor);
            await _context.SaveChangesAsync();
            return vendor;  
        }

        public Task<Models.Vendor> Delete(Models.Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Vendor> Detail(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Vendor>> GetVendors()
        {
            return await _context.Vendor.ToListAsync();
        }

        public Task<Models.Vendor> Update(Models.Vendor vendor)
        {
            throw new NotImplementedException();
        }
    }
}
