using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class WorkOrderRepository : RepositoryBase<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
