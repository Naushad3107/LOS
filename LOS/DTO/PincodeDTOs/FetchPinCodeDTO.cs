namespace LOS.DTO.PincodeDTOs
{
    public class FetchPinCodeDTO
    {
        public int PincodeId { get; set; }

        public string Pincode { get; set; }

        public string Area { get; set; }


        public int CityId { get; set; }


        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
