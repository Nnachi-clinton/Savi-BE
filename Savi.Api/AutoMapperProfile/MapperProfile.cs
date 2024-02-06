using AutoMapper;
using Savi.Core.DTO;
using Savi.Data.Repository.DTO;
using Savi.Model.Entities;

namespace Savi.Api.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Kyc, KycRequestDto>().ReverseMap();
            CreateMap<KycResponseDto, Kyc>().ReverseMap();
            CreateMap<Saving, PersonalSavingsDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUser, AppUserDto2>();
            CreateMap<GroupSavingsMembers, GroupMembersDto2>();
        }
    }
}
