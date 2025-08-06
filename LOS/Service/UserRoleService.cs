using LOS.Data;
using LOS.DTO.UserRoleDTOs;
using LOS.Repository;

namespace LOS.Service
{
    public class UserRoleService : IUserRole
    {
        ApplicationDbContext db;

        public UserRoleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserRole(AddUserRoleDTO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role cannot be null");
            }
            else
            {
                var userRole = new Models.UserRoles
                {
                    UserId = role.UserId,
                    RoleId = role.RoleId,
                    AssignedAt = DateTime.UtcNow
                };
                db.UserRoles.Add(userRole);
                db.SaveChanges();
            }
        }
    }
}
