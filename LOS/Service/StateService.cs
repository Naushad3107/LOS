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
            var data = db.States.Include(x => x.Country);
            var map = mapper.Map<List<FetchStateDTO>>(data);
            return map;

        }
    }
}
