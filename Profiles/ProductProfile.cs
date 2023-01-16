using AutoMapper;
using ExatoApi.DTOs;
using ExatoApi.Models;

namespace ExatoApi.Profiles
{
    public class ProductProfile : Profile
    {

         public ProductProfile()
        {
            CreateMap<CreateProductDto, Products>();
            CreateMap<UpdateProductDto, Products>();
            CreateMap<Products, UpdateProductDto>();
            CreateMap<Products, ReadProductDto>();
        }    
    
    }
}
