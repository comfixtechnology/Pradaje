using Pradadge.ViewModel.Business;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IStockRepositorys
    {
        void AddStockEntries(StockViewModel entity);
        void AddStockEntry(StockViewModel entity);
        IEnumerable<StockViewModel> GetAllStock();
        IQueryable<StockViewModel> GetStockById(int id);
        bool UpdateStock(StockViewModel entity);
    }
}
