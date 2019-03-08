using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) :base(options)
        { }

        public DbSet<Product> Products { get; set; }

    }
}
