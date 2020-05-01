using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest>, IEmployeeLeaveRequestRepository
    {
        private readonly UdemyEmployeeManagementContext _ctx;

        public EmployeeLeaveRequestRepository(UdemyEmployeeManagementContext ctx)
            : base(ctx)
        {
        }
    }
}
