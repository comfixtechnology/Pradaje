using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ISalesTypesRepository
    {
        SalesTypeViewModel AddSalesType(SalesTypeViewModel entity);
        IEnumerable<SalesTypeViewModel> GetAllSalesTypes();
        IQueryable<SalesTypeViewModel> GetSalesTypesById(int id);
        bool UpdateSalesType(SalesTypeViewModel entity);
    }
}
