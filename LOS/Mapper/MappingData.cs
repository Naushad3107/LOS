using AutoMapper;
using LOS.DTO.CitiesDTOs;
using LOS.DTO.CountryDTOs;
using LOS.DTO.PincodeDTOs;
using LOS.DTO.RoleDTOs;
using LOS.DTO.StateDTOs;
using LOS.DTO.USERDTOs;
using LOS.DTO.UserRoleDTOs;
using LOS.Models;

namespace LOS.Mapper
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<AddUserDTO, Users>();
            CreateMap<UpdateUserDTO, Users>();
            CreateMap<AddUserRoleDTO, UserRoles>();


            //for user roles
            CreateMap<UserRoles, AddUserRoleDTO>();
            CreateMap<UserRoles, FetchUserRole>()
                         .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                         .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));


            //for Roles
            CreateMap<Roles, AddRoleDTO>().ReverseMap();

            //for Country
            CreateMap<Countries, AddCountryDTO>().ReverseMap();
            CreateMap<Countries, UpdateCountryDTO>().ReverseMap();

            //for State
            CreateMap<States, AddStateDTO>().ReverseMap();
            CreateMap<States, FetchStateDTO>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName));
            CreateMap<States, UpdateStateDTO>().ReverseMap();


            //for city
            CreateMap<Cities, AddCitiesDTO>().ReverseMap();
            CreateMap<Cities, GetCitiesDTO>()
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.StateName));
                
            //for pincode
            CreateMap<PincodeMaster, AddPinCodeDTO>().ReverseMap();
            CreateMap<PincodeMaster, FetchPinCodeDTO>()
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.States.StateName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.CountryName));
        }
    }
    
}

