using LOS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRoles
{
    // Remove this if you want composite key with UserId+RoleId
    [Key]
    public int UserRoleId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }

    public byte IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime AssignedAt { get; set; }

    // navigation properties
    public Users User { get; set; }
    public Roles Role { get; set; }

    // Remove this List<UserRoles>, it's invalid in a join table
    // public List<UserRoles> RoleTypes { get; set; }
}
