#region Usings
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.VModels;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace EmployeeManagement.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        #endregion

        #region Constructor
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine)
        {
            _workOrderBusinessEngine = workOrderBusinessEngine;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult Create(WorkOrderVM model)
        {
            return View();
        }

        #endregion
    }
}