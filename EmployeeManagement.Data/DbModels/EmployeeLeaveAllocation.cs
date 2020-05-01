using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.DbModels
{
    public class EmployeeLeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }
    }
}
