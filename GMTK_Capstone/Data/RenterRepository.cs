using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class RenterRepository : RepositoryBase<Renter>, IRenterRepository
    {
        public RenterRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
