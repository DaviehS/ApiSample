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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var ans = _context.Products.OrderBy(a => a.Name);
            return await ans.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var ans = _context.Products.FindAsync(id);
            return await ans;
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
