using LOS.DTO.UserRoleDTOs;
using LOS.Models;

namespace LOS.Repository
{
    public interface IUserRole
    {
        void AddUserRole(AddUserRoleDTO role);

        List<FetchUserRole> FetchUserRoles();
    }
}
