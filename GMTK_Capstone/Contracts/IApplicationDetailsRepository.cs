using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IApplicationDetailsRepository : IRepositoryBase<ApplicationDetails>
    {
        ApplicationDetails GetApplicationDetails(int applicationDetailsId);
        void CreateApplicationDetails(ApplicationDetails applicationDetails);
        void EditApplicationDetails(ApplicationDetails applicationDetails);
        void DeleteApplicationDetails(ApplicationDetails applicationDetails);
    }
}
