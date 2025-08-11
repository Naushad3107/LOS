using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOS.DTO.PincodeDTOs
{
    public class AddPinCodeDTO
    {

        public int PincodeId { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }


        public int CityId { get; set; }


        public int StateId { get; set; }

        public int CountryId { get; set; }

        public Byte IsActive { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
