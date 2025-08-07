using LOS.DTO.CitiesDTOs;
using LOS.Models;

namespace LOS.Repository
{
    public interface ICities
    {
        void AddCities(AddCitiesDTO city);

        List<GetCitiesDTO> GetCities();

        void DeleteCity(int id);
    }
}
