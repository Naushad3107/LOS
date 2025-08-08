using AutoMapper;
using LOS.Data;
using LOS.DTO.PincodeDTOs;
using LOS.Models;
using LOS.Repository;
using Microsoft.EntityFrameworkCore;

namespace LOS.Service
{
    public class PincodeService : IPincode
    {
        ApplicationDbContext db;
        IMapper mapper;

        public PincodeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddPincode(AddPinCodeDTO pincode)
        {
            if (pincode == null)
            {
                throw new ArgumentNullException(nameof(pincode), "Pincode cannot be null");
            }

            var map = mapper.Map<PincodeMaster>(pincode);
            map.IsDeleted = false;

            db.pincodes.Add(map);
            db.SaveChanges();

        }

        public List<FetchPinCodeDTO> FetchPinCode()
        {
            var data = db.pincodes.Include(x => x.Countries).Include(x => x.States).ToList();
            var map = mapper.Map<List<FetchPinCodeDTO>>(data);
            return map;
        }


        public FetchPinCodeDTO FindPincodeById(int id)
        {
            var data = db.pincodes.Include(x => x.Countries).Include(x => x.States)
                .FirstOrDefault(x => x.PincodeId == id && !x.IsDeleted);
            if (data == null)
            {
                throw new KeyNotFoundException($"Pincode with ID {id} not found.");
            }
            return mapper.Map<FetchPinCodeDTO>(data);
        }

        public void DeletePincode(int id)
        {
            var pincode = db.pincodes.FirstOrDefault(r => r.PincodeId == id);
            if (pincode == null)
            {
                throw new KeyNotFoundException($"Pincode with ID {id} not found.");
            }
            try
            {
                pincode.IsDeleted = true;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(
                    "Cannot delete pincode because it is referenced as a foreign key in another table.");
            }
        }
    }
}
