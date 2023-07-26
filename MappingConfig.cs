using AutoMapper;
using cesay.QR.API.Models;
using cesay.QR.API.Models.DTO;

namespace cesay.QR.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Restaurant
            CreateMap<Restaurant, RestaurantDTO>();
            CreateMap<RestaurantCreateDTO, Restaurant>();
            CreateMap<RestaurantUpdateDTO, Restaurant>();

            // Bar
            CreateMap<Bar, BarDTO>();
            CreateMap<BarCreateDTO, Bar>();
            CreateMap<BarUpdateDTO, Bar>();

            // Kitchen
            CreateMap<Kitchen, KitchenDTO>();
            CreateMap<KitchenCreateDTO, Kitchen>();
            CreateMap<KitchenUpdateDTO, Kitchen>();

            // Table
            CreateMap<Table, TableDTO>();
            CreateMap<TableCreateDTO, Table>();
            CreateMap<TableUpdateDTO, Table>();

            // Product
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();

            // ProductMaterial
            CreateMap<ProductMaterial, ProductMaterialDTO>();
            CreateMap<ProductMaterialCreateDTO, ProductMaterial>();
            CreateMap<ProductMaterialUpdateDTO, ProductMaterial>();

            // Recipe
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeCreateDTO, Recipe>();
            CreateMap<RecipeUpdateDTO, Recipe>();

            // ProductVariant
            CreateMap<ProductVariant, ProductVariantDTO>();
            CreateMap<ProductVariantCreateDTO, ProductVariant>();
            CreateMap<ProductVariantUpdateDTO, ProductVariant>();

            // Order
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();

            // Reverse Map for Create and Update DTOs
            CreateMap<RestaurantDTO, Restaurant>().ReverseMap();
            CreateMap<BarDTO, Bar>().ReverseMap();
            CreateMap<KitchenDTO, Kitchen>().ReverseMap();
            CreateMap<TableDTO, Table>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ProductMaterialDTO, ProductMaterial>().ReverseMap();
            CreateMap<RecipeDTO, Recipe>().ReverseMap();
            CreateMap<ProductVariantDTO, ProductVariant>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
