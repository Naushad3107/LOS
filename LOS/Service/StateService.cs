using AutoMapper;
using LOS.Data;
using LOS.DTO.StateDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOS.Service
{
    public class StateService : IState
    {
        ApplicationDbContext db;
        IMapper mapper;
        public StateService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddState(AddStateDTO state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state), "State cannot be null");
            }
            else
            {
                var map = mapper.Map<States>(state);
                db.States.Add(map);
                db.SaveChanges();
            }
        }
        public List<FetchStateDTO> FetchStates()
        {
            var data = db.States.Include(x => x.Country).Where(x => x.IsDeleted == false);
            var map = mapper.Map<List<FetchStateDTO>>(data);
            return map;

        }

        public void DeleteState(int id)
        {
            var role = db.States.FirstOrDefault(r => r.StateId == id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            try
            {
                role.IsDeleted = true;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {

                throw new InvalidOperationException(
                    "Cannot delete role  because it is referenced as a foreign key in another table.");
            }
        }
    }
}
