using LOS.DTO.USERDTOs;
using LOS.Models;
using LOS.Service;

namespace LOS.Repository
{
    public interface IUserService 
    {
        void AddUser(AddUserDTO u);

        List<Users> FetchUser();

        Users FetchUserById(int UserId);
        bool UpdateUserDetails(UpdateUserDTO u,int id);

        void DeleteUser(int userId);


    }
}
