namespace LOS.DTO.StateDTOs
{
    public class FetchStateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
