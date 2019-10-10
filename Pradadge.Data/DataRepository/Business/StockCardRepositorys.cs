using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Business
{
    public class StockCardRepositorys : IStockCardRepositorys
    {
        private PradadgeContext context;
        public StockCardRepositorys (PradadgeContext context)
        {
            this.context = context;
        }

        public StockCardViewModel AddStockCard (StockCardViewModel entity)
        {
            var data = new tbl_StockCard
            {
                 
                StockId = entity.stockId,
                QuantityRecieved = entity.quantityRecieved,
                QuantitySold = entity.quantitySold,
                DateRecieved = entity.dateRecieved,
                LastDateUpdated = entity.lastDateUpdated,
                CreatedOn = entity.createdOn,
                CreatedBy = entity.createdBy
            };

            context.tbl_StockCard.Add(data);
            context.SaveChanges();
            return entity;
        }

        public void AddStockCarda(StockCardViewModel entity)
        {
            var data = new tbl_StockCard
            {

                StockId = entity.stockId,
                QuantityRecieved = entity.quantityRecieved,
                QuantitySold = entity.quantitySold,
                DateRecieved = entity.dateRecieved,
                LastDateUpdated = entity.lastDateUpdated,
                CreatedOn = entity.createdOn,
                CreatedBy = entity.createdBy
            };

            context.tbl_StockCard.Add(data);

        }

        private IQueryable<StockCardViewModel> AllStockCards ()
        {
            return from entity in context.tbl_StockCard
                   select new StockCardViewModel
                   {
                       stockCardId = entity.StockCardId,
                       stockId = entity.StockId,
                       quantityRecieved = entity.QuantityRecieved,
                       quantitySold = entity.QuantitySold,
                       dateRecieved = entity.DateRecieved,
                       lastDateUpdated = entity.LastDateUpdated,
                       //quantityRemaining = entity.QuantityRecieved - entity.QuantitySold,
                       createdOn = entity.CreatedOn
                   };
        }

        public IEnumerable<StockCardViewModel> GetAllStockCard ()
        {
            var data = AllStockCards();
            return data.ToList();
        }

        public IQueryable<StockCardViewModel> GetStockCardById (int id)
        {
            var data = AllStockCards().Where(c => c.stockCardId == id);
            return data;
        }

        public StockCardViewModel UpdateStockCard (StockCardViewModel entity)
        {
            var data = (from d in context.tbl_StockCard where d.StockCardId == entity.stockCardId select d).SingleOrDefault();
            data = new tbl_StockCard
            {
                StockCardId = entity.stockCardId,
                StockId = entity.stockId,
                QuantityRecieved = entity.quantityRecieved,
                QuantitySold = entity.quantitySold,
                DateRecieved = entity.dateRecieved,
                LastDateUpdated = entity.lastDateUpdated,
                CreatedOn = entity.createdOn,
            };

            context.tbl_StockCard.Add(data);
            context.SaveChanges();
            return entity;
        }
    }
}
