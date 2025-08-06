using AutoMapper;
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

        }
    }
    
}

