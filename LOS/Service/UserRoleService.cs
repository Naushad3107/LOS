using AutoMapper;
using LOS.Data;
using LOS.DTO.UserRoleDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOS.Service
{
    public class UserRoleService : IUserRole
    {
        ApplicationDbContext db;
        IMapper mapper;

        public UserRoleService(ApplicationDbContext db,IMapper mapper)
        {
            this.mapper = mapper;
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
               var map = mapper.Map<UserRoles>(role);
                db.UserRoles.Add(map);
                db.SaveChanges();
            }
        }

        public List<FetchUserRole> FetchUserRoles()
        {
            var data = db.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).ToList();
            var map = mapper.Map<List<FetchUserRole>>(data);

            return map;
        }
    }
}
