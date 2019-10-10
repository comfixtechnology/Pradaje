using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IDamagesRepositorys
    {
        DamagesViewModel AddDamages(DamagesViewModel entity);
        IEnumerable<DamagesViewModel> GetDamagesEncured();
        IQueryable<DamagesViewModel> GetDamagesById(int id);
        bool UpdateDamages(DamagesViewModel entity);
    }
}
