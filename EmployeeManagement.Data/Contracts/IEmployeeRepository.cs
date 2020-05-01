using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Contracts
{
    public interface IEmployeeRepository :IRepositoryBase<Employee>
    {
    }
}
