using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    [Authorize(Roles = ResultConstant.Admin_Role)]
    public class EmployeeLeaveAssignController : Controller
    {
        #region Variables
        private readonly IEmployeeLeaveAssignBusinessEngine _employeeLeaveAssignBusinessEngine;
        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;
        #endregion

        #region Constructor
        public EmployeeLeaveAssignController(IEmployeeLeaveAssignBusinessEngine employeeLeaveAssignBusinessEngine, IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine)
        {
            _employeeLeaveAssignBusinessEngine = employeeLeaveAssignBusinessEngine;
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
        }
        #endregion

        public IActionResult Index()
        {
            var data = _employeeLeaveRequestBusinessEngine.GetSendApprovedLeaveRequests();
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }

        public IActionResult Approved(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Onaylamak için Kayıt Seçiniz" });

            var data = _employeeLeaveAssignBusinessEngine.ApprovedEmployeeRequest(id);
            if (data.IsSuccess)
                return Json(new { success = data.IsSuccess, message = data.Message });
            else
                return Json(new { success = data.IsSuccess, message = data.Message });
        }
    }
}