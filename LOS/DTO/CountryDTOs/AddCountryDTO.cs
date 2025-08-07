namespace LOS.DTO.CountryDTOs
{
    public class AddCountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
