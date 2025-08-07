using LOS.DTO.StateDTOs;

namespace LOS.Repository
{
    public interface IState
    {
        void AddState(AddStateDTO state);
        List<FetchStateDTO> FetchStates();
    }
}
