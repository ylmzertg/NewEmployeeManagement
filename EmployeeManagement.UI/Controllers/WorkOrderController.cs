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
        #endregion

        #region Constructor
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine)
        {
            _workOrderBusinessEngine = workOrderBusinessEngine;
        }
        #endregion

        #region Actions
        public IActionResult Index(int pageNumber = 1)
        {
            var data = _workOrderBusinessEngine.GetAllWorkOrders();
            if (data.IsSuccess)
            {
                var model =  PaginatedList<WorkOrderVM>.CreateAsync(data.Data, pageNumber, 5);
                return View(model);
            }
            return View();
        }

        public IActionResult Create(WorkOrderVM model)
        {
            return View();
        }

        #endregion
    }
}