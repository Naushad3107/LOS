using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
