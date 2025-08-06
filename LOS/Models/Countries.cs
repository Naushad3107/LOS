using System.ComponentModel.DataAnnotations;

namespace LOS.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public bool IsActive { get; set; }
        // Navigation property for related states
        public List<States> States { get; set; }
        public List<PincodeMaster> Pincodes { get; set; }
    }
}
