using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class LandlordsRenterRepository : RepositoryBase<LandlordsRenter>, ILandlordsRenterRepository
    {
        public LandlordsRenterRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public LandlordsRenter GetLandlordsRenter(int landlordsRenterId) => FindByCondition(c => c.LandlordsRenterId.Equals(landlordsRenterId)).SingleOrDefault();
        public void CreateLandlordsRenter(LandlordsRenter landlordsRenter) => Create(landlordsRenter);
        public void EditLandlordsRenter(LandlordsRenter landlordsRenter) => Update(landlordsRenter);
        public void DeleteLandlordsRenter(LandlordsRenter landlordsRenter) => Delete(landlordsRenter);
    }
}
