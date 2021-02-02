using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class ApplicationDetailsRepository : RepositoryBase<ApplicationDetails>, IApplicationDetailsRepository
    {
        public ApplicationDetailsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public ApplicationDetails GetApplicationDetails(int applicationDetailsId) => FindByCondition(c => c.ApplicationDetailsId.Equals(applicationDetailsId)).SingleOrDefault();
        public void CreateApplicationDetails(ApplicationDetails applicationDetails) => Create(applicationDetails);
        public void EditApplicationDetails(ApplicationDetails applicationDetails) => Update(applicationDetails);
        public void DeleteApplicationDetails(ApplicationDetails applicationDetails) => Delete(applicationDetails);
    }
}
