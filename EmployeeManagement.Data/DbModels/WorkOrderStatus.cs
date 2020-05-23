using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data.DbModels
{
    public class WorkOrderStatus : BaseEntity
    {
        [Required]
        public string WorkOrderStatusName { get; set; }
    }
}
