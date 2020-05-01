using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get; }
        IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; }
        IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        void Save();
    }
}
