using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.Models
{
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        // Navigation property
        public List<Cities> Cities { get; set; }

        public List<PincodeMaster> Pincodes { get; set; }
        public Countries Country { get; set; }
    }
}
