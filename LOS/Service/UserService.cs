using LOS.Data;
using LOS.DTO.USERDTOs;
using LOS.Models;
using LOS.Repository;

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
                IsActive = u.IsActive,
                CreatedDate = u.CreatedDate

            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<Users> FetchUser()
        {
            var data = db.Users.ToList();

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
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
