using AutoMapper;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Common.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<EmployeeLeaveType, EmployeeLeaveTypeVM>().ReverseMap();
            //CreateMap<EmployeeLeaveTypeVM, EmployeeLeaveType>();
            CreateMap<EmployeeLeaveAllocation, EmployeeLeaveAllocationsVM>().ReverseMap();
            CreateMap<EmployeeLeaveRequest, EmployeeLeaveRequestVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();   
        }
    }
}
