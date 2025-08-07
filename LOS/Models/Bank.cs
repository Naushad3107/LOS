using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }

        public string BankCode { get; set; }

        public string BankName { get; set; }

        public string IFSCCode { get; set; }

        public string BranchName { get; set; }

        public string Address { get; set; }

        public Byte IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
