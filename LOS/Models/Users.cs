using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Byte IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<UserRoles> userRoles { get; set; }
    }
}
