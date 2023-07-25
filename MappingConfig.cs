using AutoMapper;
using cesay.QR.API.Models;
using cesay.QR.API.Models.Dto;

namespace cesay.QR.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Restaurant, RestaurantDTO>();
            CreateMap<RestaurantDTO, Restaurant>();

            CreateMap<Restaurant, RestaurantCreateDTO>().ReverseMap();
            CreateMap<Restaurant, RestaurantUpdateDTO>().ReverseMap();
        }
    }
}
