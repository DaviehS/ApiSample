using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Models
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductModel>().
                ForMember(c => c.Exists,
                opt => opt.MapFrom(prod => (DateTime.Now-prod.Created).Days));
        }
    }
}
