namespace LOS.Repository
{
    public interface IAuth
    {
        Task<string?> Login(string Email, string password);
    }
}
