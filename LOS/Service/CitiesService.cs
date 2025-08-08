using AutoMapper;
using LOS.Data;
using LOS.DTO.CitiesDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LOS.Service
{
    public class CitiesService : ICities
    {
        ApplicationDbContext db;
        IMapper mapper;

        public CitiesService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddCities(AddCitiesDTO city)
        {
            if (city == null)
            {
                throw new Exception(message: "city cannot be null");
            }
            else
            {
                var map = mapper.Map<Cities>(city);
                map.IsDeleted = false;
                db.cities.Add(map);
                db.SaveChanges();
            }
        }

        public List<GetCitiesDTO> GetCities()
        {
            var cities = db.cities.Where(x => x.IsDeleted == false).Include(ur => ur.State).Where(x => x.IsDeleted == false);
            if (cities == null)
            {
                throw new Exception(message: "No cities found");
            }
            else
            {
                var map = mapper.Map<List<GetCitiesDTO>>(cities);
                return map;
            }

        }

        public void DeleteCity(int id)
        {
            var city = db.cities.Find(id);
            if (city == null)
            {
                throw new KeyNotFoundException($"City with ID {id} not found.");
            }
            try
            {
                city.IsDeleted = true;
                db.SaveChanges();
            }
            catch(DbUpdateException dx)
            {
                throw new InvalidOperationException("cannot delete city as it is foreignkey");
            }
        }
    }
}
