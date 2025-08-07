namespace LOS.DTO.RoleDTOs
{
    public class AddRoleDTO
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public Byte IsActive { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
