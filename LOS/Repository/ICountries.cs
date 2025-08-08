using LOS.DTO.CountryDTOs;
using LOS.Models;

namespace LOS.Repository
{
    public interface ICountries
    {
        void AddCountry(AddCountryDTO country);

        List<Countries> GetCountries();

        void DeleteCountry(int id);

        void UpdateCountry(UpdateCountryDTO country);

        Countries FindCountryById(int id);




    }
}
