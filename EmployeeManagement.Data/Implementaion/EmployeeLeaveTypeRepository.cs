using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly UdemyEmployeeManagementContext _ctx;

        public EmployeeLeaveTypeRepository(UdemyEmployeeManagementContext ctx)
            : base(ctx)
        {
        }
    }
}
