using AutoMapper;
using Savi.Core.DTO;
using Savi.Model.Entities;

namespace Savi.Utility.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Saving, PersonalSavingsDTO>().ReverseMap();
        }
    }
}
