using LOS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.DTO.UserRoleDTOs
{
    public class AddUserRoleDTO
    {
        public int UserRoleId { get; set; }

        public string RoleName { get; set; }

      
        public int UserId { get; set; }

        
        public int RoleId { get; set; }

        public DateTime AssignedAt { get; set; }

    }
}
