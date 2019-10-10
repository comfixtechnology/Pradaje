using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    public class StatesRepository : IStatesRepository
    {
        private PradadgeContext context;
        public StatesRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public StateViewModel AddState (StateViewModel entity)
        {
            var data = new tbl_State
            {
                StateId = entity.stateId,
                StateName = entity.stateName,
                IsActive = entity.isActive,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

            context.tbl_State.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<StateViewModel> AllState ()
        {
            return from entity in context.tbl_State
                   select new StateViewModel
                   {
                       stateId = entity.StateId,
                       stateName = entity.StateName,
                       isActive = entity.IsActive,
                       createdBy = entity.CreatedBy,
                       modifiedOn = entity.ModifiedOn,
                       modifiedBy = entity.ModifiedBy
                   };
        }

        public IEnumerable<StateViewModel> GetAllStates ()
        {
            var data = AllState();
            return data.ToList();
        }

        public IQueryable<StateViewModel> GetStateById (int id)
        {
            var data = AllState().Where(c => c.stateId == id);
            return data;
        }

        public bool UpdateState (StateViewModel entity)
        {
            var data = (from d in context.tbl_State where d.StateId == entity.stateId select d).SingleOrDefault();
            if (data != null)
            {
                data.StateId = entity.stateId;
                data.StateName = entity.stateName;
                data.IsActive = entity.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = entity.modifiedBy;
            }
            return context.SaveChanges() > 0;
        }
    }
}
