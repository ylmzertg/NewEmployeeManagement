using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Common.VModels
{
    public class WorkOrderVM: BaseVM
    {
        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(750)]
        public string WorkOrderDescription { get; set; }

        public int WorkOrderStatus { get; set; }

        public double WorkOrderPoint { get; set; }

        [MaxLength(35)]
        public string WorkOrderNumber { get; set; }

        public string AssignEmployeeId { get; set; }
        [ForeignKey("AssignEmployeeId")]
        public EmployeeVM AssignEmployee { get; set; }
    }
}
