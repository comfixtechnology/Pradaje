using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IStaffRepositorys
    {
        IEnumerable<StaffViewModel> GetAllStaff();
        StaffViewModel AddStaff(StaffViewModel entity);
        IQueryable<StaffViewModel> GetStaffById(int id);
        bool UpdateStaff(StaffViewModel entity);
    }
}
