using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IStatesRepository
    {
        StateViewModel AddState(StateViewModel entity);
        IEnumerable<StateViewModel> GetAllStates();
        IQueryable<StateViewModel> GetStateById(int id);
        bool UpdateState(StateViewModel entity);
    }
}
