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
    }
}
