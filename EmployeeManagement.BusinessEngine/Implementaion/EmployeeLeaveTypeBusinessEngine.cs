using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.BusinessEngine.Implementaion
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #endregion

        #region CustomMethods

        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll(e => e.IsActive == true).ToList();

            #region 1.Yontem
            //if (data != null)
            //{
            //    List<EmployeeLeaveType> returnData = new List<EmployeeLeaveType>();
            //    foreach (var item in data)
            //    {
            //        returnData.Add(new EmployeeLeaveType()
            //        {
            //            Id = item.Id,
            //            DateCreated = item.DateCreated,
            //            DefaultDays = item.DefaultDays,
            //            Name = item.Name
            //        });
            //    }
            //    return new Result<List<EmployeeLeaveType>>(true, ResultConstant.RecordFound, returnData);
            //}
            //else
            //    return new Result<List<EmployeeLeaveType>>(false, ResultConstant.RecordNotFound); 
            #endregion

            #region 2.Yontem
            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);
            #endregion
        }

        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;
                    _unitOfWork.employeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordFound, leaveType);
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordNotFound);
        }

        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    _unitOfWork.employeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.employeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully);
        }
        #endregion
    }
}
