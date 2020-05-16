using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.Extentsion;
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
                        AssignEmployeeName = item.AssignEmployee != null ? item.AssignEmployee.Email : string.Empty,
                        CreateDate = item.CreateDate,
                        ModifiedDate = item.ModifiedDate,
                        WorkOrderDescription = item.WorkOrderDescription,
                        WorkOrderNumber = item.WorkOrderNumber,
                        WorkOrderPoint = item.WorkOrderPoint,
                        WorkOrderStatus = (EnumWorkOrderStatus)item.WorkOrderStatus,
                        WorkOrderStatusText = EnumExtension<EnumWorkOrderStatus>.GetDisplayValue((EnumWorkOrderStatus)item.WorkOrderStatus)
                    });
                }
                return new Result<List<WorkOrderVM>>(true, ResultConstant.RecordFound, returnData.OrderByDescending(x => x.CreateDate).ToList());
            }
            else
                return new Result<List<WorkOrderVM>>(false, ResultConstant.RecordNotFound);
            #endregion
        }

        public Result<WorkOrderVM> CreateWorkOrder(WorkOrderVM model)
        {
            if (model != null)
            {
                try
                {
                    WorkOrder wOrder = new WorkOrder();
                    wOrder.CreateDate = DateTime.Now;
                    wOrder.WorkOrderDescription = model.WorkOrderDescription;
                    wOrder.WorkOrderNumber = DateTime.Now.ToString();
                    wOrder.WorkOrderPoint = model.WorkOrderPoint;
                    wOrder.WorkOrderStatus = (int)EnumWorkOrderStatus.WorkOrder_Created;

                    _unitOfWork.workOrderRepository.Add(wOrder);
                    _unitOfWork.Save();
                    return new Result<WorkOrderVM>(true, ResultConstant.RecordCreateSuccessfully, model);
                }
                catch (Exception ex)
                {
                    return new Result<WorkOrderVM>(false, ResultConstant.RecordCreateNotSuccessfully);
                }
            }
            else
                return new Result<WorkOrderVM>(false, "Model Null Gelemez");
        }

        public Result<WorkOrderVM> GetWorkOrder(int id)
        {
            if (id > 0)
            {
                var workOrder = _unitOfWork.workOrderRepository.GetFirstOrDefault(u => u.Id == id, includeProperties: "AssignEmployee");
                if (workOrder != null)
                {
                    WorkOrderVM wOrder = new WorkOrderVM();
                    wOrder.AssignEmployeeId = workOrder.AssignEmployeeId;
                    wOrder.AssignEmployeeName = workOrder.AssignEmployee != null ? workOrder.AssignEmployee.FirstName : string.Empty;
                    wOrder.CreateDate = workOrder.CreateDate;
                    wOrder.Id = workOrder.Id;
                    wOrder.ModifiedDate = workOrder.ModifiedDate;
                    wOrder.WorkOrderDescription = workOrder.WorkOrderDescription;
                    wOrder.WorkOrderNumber = workOrder.WorkOrderNumber;
                    wOrder.WorkOrderPoint = workOrder.WorkOrderPoint;
                    wOrder.WorkOrderStatus = (EnumWorkOrderStatus)workOrder.WorkOrderStatus;
                    wOrder.WorkOrderStatusText = EnumExtension<EnumWorkOrderStatus>.GetDisplayValue((EnumWorkOrderStatus)workOrder.WorkOrderStatus);
                    return new Result<WorkOrderVM>(true, ResultConstant.RecordFound, wOrder);
                }
                else
                    return new Result<WorkOrderVM>(false, ResultConstant.RecordNotFound);
            }
            else
                return new Result<WorkOrderVM>(false, ResultConstant.RecordNotFound);
        }

        public Result<WorkOrderVM> EditWorkOrder(WorkOrderVM editModel)
        {
            if (editModel.Id > 0)
            {
                var data = _unitOfWork.workOrderRepository.Get(editModel.Id);
                if (data != null)
                {
                    data.ModifiedDate = DateTime.Now;
                    data.WorkOrderDescription = editModel.WorkOrderDescription;
                    data.WorkOrderPoint = editModel.WorkOrderPoint;
                    data.WorkOrderStatus = (int)editModel.WorkOrderStatus;
                    data.AssignEmployeeId = editModel.AssignEmployeeId;

                    _unitOfWork.workOrderRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<WorkOrderVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                else
                    return new Result<WorkOrderVM>(false, "Lütfen Güncelleme İşlemi İçin Data Seçiniz");
            }
            else
                return new Result<WorkOrderVM>(false, "Lütfen Güncelleme İşlemi İçin Data Seçiniz");
        }

        public Result<bool> RemoveWorkOrder(int id)
        {
            var data = _unitOfWork.workOrderRepository.Get(id);
            if (data != null)
            {
                _unitOfWork.workOrderRepository.Remove(data);
                _unitOfWork.Save();
                return new Result<bool>(true, ResultConstant.RecordRemoveSuccessfully);
            }
            else
                return new Result<bool>(false, ResultConstant.RecordRemoveNotSuccessfully);
        }
        #endregion
    }
}
