namespace LOS.DTO.USERDTOs
{
    public class AddUserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
