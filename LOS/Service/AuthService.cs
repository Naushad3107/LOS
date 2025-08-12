
using LOS.Data;
using LOS.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LOS.Service
{
    public class AuthService : IAuth
    {
        ApplicationDbContext db;
        IUserService userService;
        IToken token;

        public AuthService(ApplicationDbContext db, IUserService userService, IToken token)
        {
            this.db = db;
            this.userService = userService;
            this.token = token;
        }

        public async Task<string?> Login(string Email, string password)
        {
            var user =await userService.GetByEmailWithRolesAsync(Email);
            if (user == null) {
                return null;
            }
            
            if(user.PasswordHash != password)
            {
                return "Invalid Password";
            }
            else
            {
                token.GenerateToken(user);
                return "Log-in Successful";
            }
        }
    }
}
