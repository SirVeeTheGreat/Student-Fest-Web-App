using Studfest.Models;

namespace Studfest.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>>GetAllProducts();
        Task<Product> GetProductById(int id); 
        Task<Product> Detail(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
    }
}
 