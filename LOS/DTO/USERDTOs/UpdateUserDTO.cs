using System.ComponentModel.DataAnnotations;

namespace LOS.DTO.USERDTOs
{
    public class UpdateUserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Boolean IsActive { get; set; }
    }
}
