using AutoMapper;
using LOS.Data;
using LOS.DTO.RoleDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOS.Service
{
    public class RoleService : IRole
    {
        ApplicationDbContext db;
        IMapper mapper;
        public RoleService(ApplicationDbContext db,IMapper mapper) 
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddRole(AddRoleDTO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role cannot be null");
            }
            else
            {
                var map = mapper.Map<Roles>(role);
                db.Roles.Add(map);
                db.SaveChanges();
            }
        }

        public List<Roles> FetchRoles()
        {
            
            var data = db.Roles.ToList();
           
                return data;        

        }

        public void DeleteRole(int id)
        {
            var role = db.Roles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            try
            {
                db.Roles.Remove(role);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {

                throw new InvalidOperationException(
                    "Cannot delete role  because it is referenced as a foreign key in another table.");
            }
        }


        public Roles FindById(int id)
        {
            var role = db.Roles.FirstOrDefault(x => x.RoleId == id);
            return role;

        }

    }
}
