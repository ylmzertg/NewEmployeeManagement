using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyEmployeeManagementContext _ctx;

        public UnitOfWork(UdemyEmployeeManagementContext ctx)
        {
            _ctx = ctx;
            employeeLeaveAllocation = new EmployeeLeaveAllocationRepository(_ctx);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
            employeeRepository = new EmployeeRepository(_ctx);
        }

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get; private set; }
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set; }


        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
