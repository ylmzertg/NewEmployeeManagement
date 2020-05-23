#region Usings
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.PagingListModels;
using EmployeeManagement.Common.VModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
#endregion

namespace EmployeeManagement.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        private readonly IEmployeeBusinessEngine _employeeBusinessEngine;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        [System.Obsolete]
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine, IEmployeeBusinessEngine employeeBusinessEngine, IHostingEnvironment hostingEnvironment)
        {
            _workOrderBusinessEngine = workOrderBusinessEngine;
            _employeeBusinessEngine = employeeBusinessEngine;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Actions
        public IActionResult Index(string employeeId, int pageNumber = 1)
        {
            if (!String.IsNullOrWhiteSpace(employeeId))
            {
                var dataWithEmployee = _workOrderBusinessEngine.GetWorkOrderByEmployeeId(employeeId);
                var model = PaginatedList<WorkOrderVM>.CreateAsync(dataWithEmployee.Data, pageNumber, 5);
                return View(model);
            }
            var data = _workOrderBusinessEngine.GetAllWorkOrders();
            if (data.IsSuccess)
            {
                var model = PaginatedList<WorkOrderVM>.CreateAsync(data.Data, pageNumber, 5);
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkOrderVM model)
        {
            string uniqueFileName = null;
            if (model.PhotoPath != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CustomImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
            }


            var result = _workOrderBusinessEngine.CreateWorkOrder(model, uniqueFileName);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.EmployeeList = _employeeBusinessEngine.GetAllEmployee().Data;
            var data = _workOrderBusinessEngine.GetWorkOrder(id).Data;
            return View(data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(WorkOrderVM editModel)
        {
            var data = _workOrderBusinessEngine.EditWorkOrder(editModel);
            if (data.IsSuccess)
                return RedirectToAction("Index");
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek için Kayıt Seçiniz" });

            var data = _workOrderBusinessEngine.RemoveWorkOrder(id);
            if (data.IsSuccess)
                return Json(new { success = data.IsSuccess, message = data.Message });
            else
                return Json(new { success = data.IsSuccess, message = data.Message });
        }

        public ActionResult GetWorkOrderByEmployeeId(string Id)
        {
            var data = _workOrderBusinessEngine.GetWorkOrderByEmployeeId(Id);
            if (data.IsSuccess)
                return Json(new { isSuccess = data.IsSuccess, message = data.Message, data = data.Data });
            return RedirectToAction("Index", new { employeeId = Id });
        }

        //Asynchorouns Programming Model
        //Event Based Asynchorouns Pattern
        //Task Parallel - Task-base Asynchorouns Pattern/Programming

        #endregion
    }
}