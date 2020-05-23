using AutoMapper;
using EmployeeManagement.BusinessEngine.Implementaion;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.PagingListModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.ViewComponents
{
    public class EmployeeListViewComponent : ViewComponent
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeListViewComponent(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region CustomMethod

        /// <summary>
        /// Employee Id Ve Status ıle Is Emrı Getırme(Atanmıs)
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _uow.employeeRepository.GetAll(e => e.IsActive == true && e.IsAdmin != true).ToList();

            if (data != null)
            {
                var mappingData = _mapper.Map<List<Employee>, List<EmployeeVM>>(data);
                ViewBag.EmployeeList = mappingData;
                return View(mappingData);
            }
            return View();
        }
        #endregion
    }
}
