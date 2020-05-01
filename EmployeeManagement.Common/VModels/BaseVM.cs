using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.VModels
{
    public class BaseVM
    {
        [Key]
        public int Id { get; set; }
    }
}
