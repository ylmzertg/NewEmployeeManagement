using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ConstantsModels
{
    public enum EnumWorkOrderStatus
    {
        [Display(Name = "İş Emri Oluşturuldu")]
        WorkOrder_Created = 1,

        [Display(Name = "Atandı")]
        Assigned = 2,

        [Display(Name = "Üstlenildi")]
        Undertake = 3,

        [Display(Name = "Kapatıldı")]
        Closed = 4
    }
}
