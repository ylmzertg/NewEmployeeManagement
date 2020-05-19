using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeBusinessEngine
    {
        Result<List<EmployeeVM>> GetAllEmployee();
        Result<List<WorkOrderVM>> GetWorkOrderByEmployeeId(string employeeId, EnumWorkOrderStatus workOrderStatus);
    }
}
