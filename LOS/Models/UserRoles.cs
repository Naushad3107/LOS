using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }

        public string RoleName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public DateTime AssignedAt { get; set; }

        //navigation
        public Users User { get; set; }

        public Roles Role { get; set; }
    }
}
