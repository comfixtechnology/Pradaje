using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ISalesDetailRepository
    {
        bool SaleProduct(List<SalesDetailsViewModel> orders);
        SalesDetailsViewModel AddSalesDetails(SalesDetailsViewModel entity);
        IEnumerable<SalesDetailsViewModel> GetAllSalesDetails();
        IQueryable<SalesDetailsViewModel> GetSalesDetailsById(int id);
        bool UpdateSalesDetails(SalesDetailsViewModel entity);
    }
}
