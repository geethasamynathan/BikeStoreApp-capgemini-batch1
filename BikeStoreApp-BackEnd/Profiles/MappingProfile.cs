using AutoMapper;
using BikeStoreApp_BackEnd.DTO;
using BikeStoreApp_BackEnd.Models;

namespace BikeStoreApp_BackEnd.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();


            CreateMap<ProductDTO, Product>();

            CreateMap<Category, CategoryDTO>();

            CreateMap<CategoryDTO, Category>();

            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryDTO, Inventory>();
        }
    }
}
