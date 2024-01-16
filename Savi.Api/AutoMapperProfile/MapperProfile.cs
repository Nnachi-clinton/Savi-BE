using AutoMapper;
using Savi.Core.DTO;
using Savi.Model.Entities;

namespace Savi.Api.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Kyc, KycRequestDto>().ReverseMap();
            CreateMap<KycResponseDto, Kyc>().ReverseMap();
            CreateMap<UpdateKycDto, Kyc>().ReverseMap();
            CreateMap<AppUser, AppUserDto>();
        }
    }
}
