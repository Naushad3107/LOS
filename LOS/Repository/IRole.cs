using LOS.DTO.RoleDTOs;
using LOS.DTO.UserRoleDTOs;
using LOS.Models;

namespace LOS.Repository
{
    public interface IRole
    {
        void AddRole(AddRoleDTO role);

        List<Roles> FetchRoles();

        Roles FindById(int id);

        void DeleteRole(int id);

    }
}
