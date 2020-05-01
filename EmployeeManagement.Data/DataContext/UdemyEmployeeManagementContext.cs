using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.DataContext
{
    public class UdemyEmployeeManagementContext : IdentityDbContext
    {
        public UdemyEmployeeManagementContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public DbSet<EmployeeLeaveRequest> EmployeeLeaveRequests { get; set; }
        public DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; }
    }
}
