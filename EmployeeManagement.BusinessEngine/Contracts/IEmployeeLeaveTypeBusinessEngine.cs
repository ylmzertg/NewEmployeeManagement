using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();

        /// <summary>
        /// New Employee Leave Type Create method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);

        /// <summary>
        /// Get Employee Leave Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id);

        Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model);

        Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id);
    }
}
