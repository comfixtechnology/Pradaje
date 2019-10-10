using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IBankRepository
    {
        BanksViewModel AddBank(BanksViewModel entity);
        List<BanksViewModel> GetAllBanks();
        IEnumerable<BanksViewModel> GetBank(int id);
        bool UpdateBank(BanksViewModel entity);
    }
}
