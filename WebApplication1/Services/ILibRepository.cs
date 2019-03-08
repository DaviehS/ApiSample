using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
    public interface ILibRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<bool> AddProductAsync(Product p);
        Task<bool> SaveAllAsync();

    }
}