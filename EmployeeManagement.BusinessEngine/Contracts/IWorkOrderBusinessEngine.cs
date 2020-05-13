
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IWorkOrderBusinessEngine
    {
        Result<List<WorkOrderVM>> GetAllWorkOrders();
    }
}
