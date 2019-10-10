using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IStockCardRepositorys
    {
        StockCardViewModel AddStockCard(StockCardViewModel entity);
        IEnumerable<StockCardViewModel> GetAllStockCard();
        IQueryable<StockCardViewModel> GetStockCardById(int id);
        StockCardViewModel UpdateStockCard(StockCardViewModel entity);
        void AddStockCarda(StockCardViewModel entity);
    }
}
