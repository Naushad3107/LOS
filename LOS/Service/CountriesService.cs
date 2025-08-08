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
                map.IsDeleted = false;

                db.countries.Add(map);
                db.SaveChanges();
            }
        }

        public List<Countries> GetCountries() 
        {
            var data = db.countries.Where(x => x.IsDeleted == false).ToList();
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

                data.IsDeleted = true;
                db.SaveChanges();
            }

        }

        public Countries FindCountryById(int id)
        {
            var data = db.countries.Where(x => x.IsDeleted == false).FirstOrDefault();
            return data;
        }

        public void UpdateCountry(UpdateCountryDTO country)
        {
            var data = FindCountryById(country.CountryId);

            if (data == null)
            {
                throw new Exception(message: "Country not found");
            }
            else
            {
                var map = mapper.Map<UpdateCountryDTO, Countries>(country, data);
                map.IsDeleted = false;
                db.countries.Update(map);
                db.SaveChanges();
            }
        }

    }
}
