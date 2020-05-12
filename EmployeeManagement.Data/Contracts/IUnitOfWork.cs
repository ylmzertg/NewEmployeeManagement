using System;

namespace EmployeeManagement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get; }
        IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; }
        IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        IWorkOrderRepository workOrderRepository { get; }
        void Save();
    }
}
