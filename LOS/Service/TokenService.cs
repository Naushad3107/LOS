using LOS.Data;
using LOS.Models;
using LOS.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LOS.Service
{
    public class TokenService : IToken
    {
        ApplicationDbContext db;
        IConfiguration config;
        public TokenService(ApplicationDbContext db,IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public string GenerateToken(Users user)
        {
            var cfg = config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(cfg["SecretKey"]));
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            //extracting the roles is done in this part
            var rolename = user.userRoles.Select(ur => ur.Role.RoleName).Distinct().ToList();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            claims.AddRange(rolename.Select(r => new Claim(ClaimTypes.Role,r)));

            var token = new JwtSecurityToken(
            issuer: cfg["Issuer"],
            audience: cfg["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(cfg["ExpiryInMinutes"]!)),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
