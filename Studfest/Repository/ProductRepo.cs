using Microsoft.EntityFrameworkCore;
using Studfest.Data;
using Studfest.Interface;
using Studfest.Models;

namespace Studfest.Repository
{
    public class ProductRepo : IProduct
    {
        public readonly StudentFestDb _context;
        public ProductRepo(StudentFestDb context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Detail(int id)
        {
           return await _context.Products.FirstOrDefaultAsync( i => i.Id == id);
           
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
