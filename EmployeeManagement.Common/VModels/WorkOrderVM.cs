using EmployeeManagement.Common.ConstantsModels;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Common.VModels
{
    public class WorkOrderVM : BaseVM
    {
        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(750)]
        public string WorkOrderDescription { get; set; }

        public EnumWorkOrderStatus WorkOrderStatus { get; set; }

        public string WorkOrderStatusText { get; set; }

        [Required]
        public double WorkOrderPoint { get; set; }

        [MaxLength(35)]
        public string WorkOrderNumber { get; set; }

        public IFormFile PhotoPath { get; set; }
        public string PhotoPathText { get; set; }

        public string AssignEmployeeId { get; set; }
        public string AssignEmployeeName { get; set; }
        [ForeignKey("AssignEmployeeId")]
        public EmployeeVM AssignEmployee { get; set; }
    }
}
