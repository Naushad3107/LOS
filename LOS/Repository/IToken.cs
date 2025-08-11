using LOS.Models;

namespace LOS.Repository
{
    public interface IToken
    {
        string GenerateToken(Users user);
    }
}
