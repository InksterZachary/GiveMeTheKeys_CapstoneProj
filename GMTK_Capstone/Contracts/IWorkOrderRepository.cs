using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IWorkOrderRepository : IRepositoryBase<WorkOrder>
    {
        WorkOrder GetWorkOrder(int workOrderId);
        void CreateWorkOrder(WorkOrder workOrder);
        void EditWorkOrder(WorkOrder workOrder);
        void DeleteWorkOrder(WorkOrder workorder);
    }
}
