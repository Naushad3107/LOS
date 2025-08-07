using AutoMapper;
using LOS.Data;
using LOS.DTO.CountryDTOs;
using LOS.Models;
using LOS.Repository;

namespace LOS.Service
{
    public class CountriesService : ICountries
    {
        ApplicationDbContext db;
        IMapper mapper;
        public CountriesService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddCountry(AddCountryDTO country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country), "Country cannot be null");
            }
            else {
                var map = mapper.Map<Countries>(country);

                db.countries.Add(map);
                db.SaveChanges();
            }
        }

        public List<Countries> GetCountries() 
        {
            var data = db.countries.ToList();
            return data;
        }

        public void DeleteCountry(int id) 
        {
            var data = db.countries.FirstOrDefault(x => x.CountryId == id);
            if (data == null)
            {
                throw new Exception(message : "Country not found");
            }
            else
            {

                db.countries.Remove(data);
                db.SaveChanges();
            }

        }

    }
}
