using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface ILandlordRepository : IRepositoryBase<Landlord>
    {
        Landlord GetLandlord(int landlordId);
        void CreateLandlord(Landlord landlord);
        void EditLandlord(Landlord landlord);
        void DeleteLandlord(Landlord landlord);
        Landlord GetLandlord(string userId);
    }
}
