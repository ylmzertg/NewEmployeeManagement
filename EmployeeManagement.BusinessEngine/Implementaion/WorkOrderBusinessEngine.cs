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
    public class WorkOrderBusinessEngine : IWorkOrderBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkOrderBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region CustomMethods

        public Result<List<WorkOrderVM>> GetAllWorkOrders()
        {
            var data = _unitOfWork.workOrderRepository.GetAll(includeProperties: "AssignEmployee").ToList();
            #region 1.Yontem
            if (data != null)
            {
                List<WorkOrderVM> returnData = new List<WorkOrderVM>();
                foreach (var item in data)
                {
                    returnData.Add(new WorkOrderVM()
                    {
                        Id = item.Id,
                        AssignEmployeeId = item.AssignEmployeeId,
                        AssignEmployeeName = item.AssignEmployee.Email,
                        CreateDate = item.CreateDate,
                        ModifiedDate = item.ModifiedDate,
                        WorkOrderDescription = item.WorkOrderDescription,
                        WorkOrderNumber = item.WorkOrderNumber,
                        WorkOrderPoint = item.WorkOrderPoint,
                        WorkOrderStatus = item.WorkOrderStatus
                    });
                }
                return new Result<List<WorkOrderVM>>(true, ResultConstant.RecordFound, returnData);
            }
            else
                return new Result<List<WorkOrderVM>>(false, ResultConstant.RecordNotFound);
            #endregion
        }

        #endregion
    }
}
