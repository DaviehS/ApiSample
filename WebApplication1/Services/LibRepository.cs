using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
    public class LibRepository : ILibRepository
    { 
        public TestContext _context { get; set; }
        public LibRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            var ans = _context.Products.Include(a=>a.Locations);
         
            return await ans.OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var ans = await _context.Products.FindAsync(id);
            return ans;
        }
        public async Task<bool> AddProductAsync(Product p)
        {
            _context.Products.Add(p);
            return await SaveAllAsync();
        }
  
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
