using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveAssignBusinessEngine
    {
        Result<bool> ApprovedEmployeeRequest(int id);
    }
}
