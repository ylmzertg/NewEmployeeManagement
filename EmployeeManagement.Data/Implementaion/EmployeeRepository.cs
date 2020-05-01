using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly UdemyEmployeeManagementContext _ctx;

        public EmployeeRepository(UdemyEmployeeManagementContext ctx)
            : base(ctx)
        {
        }
    }
}
