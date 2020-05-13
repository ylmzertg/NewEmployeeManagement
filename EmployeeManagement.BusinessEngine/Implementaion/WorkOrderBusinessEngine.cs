using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public void Add(WorkOrder entity)
        {
            throw new NotImplementedException();
        }

        public WorkOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorkOrder> GetAll(Expression<Func<WorkOrder, bool>> filter = null, Func<IQueryable<WorkOrder>, IOrderedQueryable<WorkOrder>> orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public WorkOrder GetFirstOrDefault(Expression<Func<WorkOrder, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(WorkOrder entity)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkOrder entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
