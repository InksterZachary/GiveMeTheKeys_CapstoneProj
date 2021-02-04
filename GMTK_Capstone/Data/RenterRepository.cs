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
        public Renter GetRenter(int renterId) => FindByCondition(c => c.RenterId.Equals(renterId)).SingleOrDefault();
        public Renter GetRenter(string renterId) => FindByCondition(c => c.IdentityUserId.Equals(renterId)).SingleOrDefault();
        public void CreateRenter(Renter renter) => Create(renter);
        public void EditRenter(Renter renter) => Update(renter);
        public void DeleteRenter(Renter renter) => Delete(renter);
    }
}
