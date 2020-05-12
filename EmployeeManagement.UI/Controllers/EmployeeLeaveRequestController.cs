using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeLeaveRequestController : Controller
    {
        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;
        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine;

        public EmployeeLeaveRequestController(IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine, IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }

        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(ResultConstant.LoginUserInfo));

            var requestModel = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestByUserId(user.LoginId);
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (requestModel.IsSuccess)
                return View(requestModel.Data);

            return View(user);
        }

        public IActionResult Create()
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeLeaveRequestVM model, int? id)
        {
            var user = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(ResultConstant.LoginUserInfo));
            #region CreateOrEditExample
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.EditEmployeeLeaveRequest(model, user);
                return RedirectToAction("Index");
            }
            else
            {
                var data = _employeeLeaveRequestBusinessEngine.CreateEmployeeLeaveRequest(model, user);
                if (data.IsSuccess)
                    return RedirectToAction("Index");
                return View(model);
            }
            #endregion
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestById((int)id);
                return View(data.Data);
            }
            else
                return View();
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek için Kayıt Seçiniz" });

            var data = _employeeLeaveRequestBusinessEngine.RemoveEmployeeRequest(id);
            if (data.IsSuccess)
                return Json(new { success = data.IsSuccess, message = data.Message });
            else
                return Json(new { success = data.IsSuccess, message = data.Message });
        }

        public ActionResult Reject(int id)
        {
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.RejectEmployeeLeaveRequest((int)id);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

    }
}