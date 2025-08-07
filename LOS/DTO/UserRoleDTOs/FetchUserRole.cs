namespace LOS.DTO.UserRoleDTOs
{
    public class FetchUserRole
    {
        public int UserRoleId { get; set; }  // Assuming a primary key in UserRoles

        public int UserId { get; set; }      // Foreign key to User

        public int RoleId { get; set; }      // Related role Id

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
