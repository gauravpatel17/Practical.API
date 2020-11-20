using AutoMapper;
using Gaurav.Practical.API.Dto;
using Gaurav.Practical.API.Model;

namespace Gaurav.Practical.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ColorDto, Color>();
            CreateMap<ColorCodeDto, ColorCode>();
        }
    }
}
