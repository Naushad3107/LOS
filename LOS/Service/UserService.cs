using LOS.Data;
using LOS.DTO.USERDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOS.Service
{
    public class UserService : IUserService
    {
        ApplicationDbContext db;
        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddUser(AddUserDTO u)
        {
            var user = new Users
            {
                UserName = u.UserName,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                //IsActive = u.IsActive
                CreatedDate = u.CreatedDate

            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<Users> FetchUser()
        {
            var data = db.Users.Where(x => x.IsDeleted == false).ToList();

            return data;
        }

        public Users FetchUserById(int UserId)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == UserId);
            return user;
        }
        public bool UpdateUserDetails(UpdateUserDTO u, int id)
        {

            var user = db.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return false;
            }


            user.UserName = u.UserName;
            user.Email = u.Email;
            user.PasswordHash = u.PasswordHash;

            db.SaveChanges();
            return true;
        }


        public void DeleteUser(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsDeleted = true; // Soft delete
                db.SaveChanges();
            }
        }

        public bool VerifyPasswordAsync(Users user, string password)
        {
            bool stat = false;
            if (user.PasswordHash == password) {
                stat = true;
            }
            else
            {
                stat = false;
            }
                return stat; 
        }
        public async Task<Users?> GetByEmailWithRolesAsync(string email)
        {
            return await db.Users
                .Include(u => u.userRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}

