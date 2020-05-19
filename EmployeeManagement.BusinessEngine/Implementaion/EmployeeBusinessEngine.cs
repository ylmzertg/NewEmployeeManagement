using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.BusinessEngine.Implementaion
{
    public class EmployeeBusinessEngine : IEmployeeBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region CustomMethods

        public Result<List<EmployeeVM>> GetAllEmployee()
        {
            var data = _unitOfWork.employeeRepository.GetAll();
            if (data != null)
            {
                List<EmployeeVM> listData = new List<EmployeeVM>();
                foreach (var item in data)
                {
                    listData.Add(new EmployeeVM
                    {
                        DateOfBirth = item.DateOfBirth,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        Id = item.Id,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber,
                        TaxId = item.TaxId,
                        UserName = item.UserName
                    });
                }
                return new Result<List<EmployeeVM>>(true, ResultConstant.RecordFound, listData);

            }
            return new Result<List<EmployeeVM>>(false, ResultConstant.RecordNotFound);
        }

        public Result<List<WorkOrderVM>> GetWorkOrderByEmployeeId(string employeeId, EnumWorkOrderStatus workOrderStatus)
        {
            var data = _unitOfWork.workOrderRepository.
                            GetAll(u => u.AssignEmployeeId == employeeId
                                    && u.WorkOrderStatus == (int)workOrderStatus).ToList();
            if (data != null)
            {
                var workOrderVm = _mapper.Map<List<WorkOrder>, List<WorkOrderVM>>(data);
                return new Result<List<WorkOrderVM>>(true, ResultConstant.RecordFound, workOrderVm);
            }
            else
                return new Result<List<WorkOrderVM>>(false, ResultConstant.RecordNotFound);
        }

        #endregion
    }
}
