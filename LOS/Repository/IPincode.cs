using LOS.DTO.PincodeDTOs;

namespace LOS.Repository
{
    public interface IPincode
    {
        void AddPincode(AddPinCodeDTO pincode);

        List<FetchPinCodeDTO> FetchPinCode();

        void DeletePincode(int id);

        FetchPinCodeDTO FindPincodeById(int id);
    }
}
