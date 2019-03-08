using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price{ get; set; }
        public string Description{ get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public string Seller { get; set; }

        public ICollection<Location> Locations { get; set; }

    }
}
