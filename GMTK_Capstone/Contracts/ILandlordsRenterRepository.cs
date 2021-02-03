using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface ILandlordsRenterRepository : IRepositoryBase<LandlordsRenter>
    {
        LandlordsRenter GetLandlordsRenter(int landlordsRenterId);
        void CreateLandlordsRenter(LandlordsRenter landlordsRenter);
        void EditLandlordsRenter(LandlordsRenter landlordsRenter);
        void DeleteLandlordsRenter(LandlordsRenter landlordsRenter);
    }
}
