using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        private readonly UdemyEmployeeManagementContext _ctx;

        public WorkOrderRepository(UdemyEmployeeManagementContext ctx) 
            :base(ctx)
        {
            _ctx = ctx;
        }
    }
}
