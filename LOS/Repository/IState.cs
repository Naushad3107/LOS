using LOS.DTO.StateDTOs;
using LOS.Models;

namespace LOS.Repository
{
    public interface IState
    {
        void AddState(AddStateDTO state);
        List<FetchStateDTO> FetchStates();

        void DeleteState(int id);

        States FindStateById(int id);

        void UpdateState(UpdateStateDTO state);
    }
}
