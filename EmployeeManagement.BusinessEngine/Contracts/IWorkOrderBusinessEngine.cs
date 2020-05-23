
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IWorkOrderBusinessEngine
    {
        Result<List<WorkOrderVM>> GetAllWorkOrders();
        Result<WorkOrderVM> CreateWorkOrder(WorkOrderVM model,string uniqueFileName);
        Result<WorkOrderVM> GetWorkOrder(int id);
        Result<WorkOrderVM> EditWorkOrder(WorkOrderVM editModel);
        Result<bool> RemoveWorkOrder(int id);
        Result<List<WorkOrderVM>> GetWorkOrderByEmployeeId(string employeeId);
    }
}
