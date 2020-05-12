using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveRequestBusinessEngine
    {
        Result<List<EmployeeLeaveRequestVM>> GetAllLeaveRequestByUserId(string userId);
        Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM model,SessionContext user);
        Result<EmployeeLeaveRequestVM> EditEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user);
        Result<EmployeeLeaveRequestVM> GetAllLeaveRequestById(int id);
        Result<EmployeeLeaveRequestVM> RemoveEmployeeRequest(int id);
        Result<List<EmployeeLeaveRequestVM>> GetSendApprovedLeaveRequests();
        Result<bool> RejectEmployeeLeaveRequest(int id);
    }
}
