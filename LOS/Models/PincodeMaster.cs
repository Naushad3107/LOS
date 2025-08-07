using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.Models
{
    public class PincodeMaster
    {
        [Key]
        public int PincodeId { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("States")]
        public int StateId { get; set; }

        [ForeignKey("Countries")]
        public int CountryId { get; set; }

        public Byte IsActive { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; }

        //navigation prop

        public Cities City { get; set; }

        public States States { get; set; }

        public Countries Countries { get; set; }
    }
}
