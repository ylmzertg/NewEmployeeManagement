#region Usings
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.PagingListModels;
using EmployeeManagement.Common.VModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
#endregion

namespace EmployeeManagement.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        private readonly IEmployeeBusinessEngine _employeeBusinessEngine;
        #endregion

        #region Constructor
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine, IEmployeeBusinessEngine employeeBusinessEngine)
        {
            _workOrderBusinessEngine = workOrderBusinessEngine;
            _employeeBusinessEngine = employeeBusinessEngine;
        }
        #endregion

        #region Actions
        public IActionResult Index(int pageNumber = 1)
        {
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
            var result = _workOrderBusinessEngine.CreateWorkOrder(model);
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

        #endregion
    }
}