using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IBranchRepository
    {
        BranchViewModel AddBranch(BranchViewModel entity);
        IEnumerable<BranchViewModel> GetBranch();
        IQueryable<BranchViewModel> GetBranchById(int id);
        bool UpdateBranch(BranchViewModel branch);

    }
}
