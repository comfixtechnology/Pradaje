using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Business
{
    public class StockRepositorys : IStockRepositorys
    {
        private PradadgeContext context;
        private IStockCardRepositorys card;
        public StockRepositorys (PradadgeContext context, IStockCardRepositorys card)
        {
            this.context = context;
            this.card = card;
        }

        public void AddStockEntries(StockViewModel entity)
        {
            var data = new tbl_Stock
            {
                ProductId = entity.productId,
                StockCode = entity.stockCode,
                PurchaseOrderDetailId = entity.purchaseOrderDetailId,
                PurchaseOrderId = entity.purchaseOrderId,
                QuantitySupplied = entity.quantitySupplied,
                SupplyDate = DateTime.Now,
                CostPerItem = entity.costPerItem,
                SellingPrice = entity.sellingPrice,
                BranchId = entity.branchId,
                DeliveryDate = DateTime.Now,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin"
            };
            context.tbl_Stock.Add(data);
            //return context.SaveChanges() > 0;
       
        }


        public void AddStockEntry (StockViewModel entity)
        {
               var data = new tbl_Stock
                { 
                    ProductId = entity.productId,
                    StockCode = entity.stockCode,
                    PurchaseOrderDetailId = entity.purchaseOrderDetailId,
                    PurchaseOrderId = entity.purchaseOrderId, 
                    QuantitySupplied = entity.quantitySupplied,
                    SupplyDate = entity.supplyDate,
                    CostPerItem = entity.costPerItem,
                    SellingPrice = entity.sellingPrice,
                    BranchId = entity.branchId,
                    DeliveryDate = entity.deliveryDate,
                    IsActive = true, 
                    CreatedOn = entity.createdOn,
                    CreatedBy = "admin",
                  
                };
            
            

            context.tbl_Stock.Add(data);
            //context.SaveChanges();
            //data.StockId = data.StockId;

            var stockCard = new StockCardViewModel
            {
                dateRecieved = data.DeliveryDate,
                quantityRecieved = data.QuantitySupplied,
                stockId = data.StockId,
                createdOn = entity.createdOn,
                createdBy = data.CreatedBy,
                lastDateUpdated= DateTime.Now   

            };
            card.AddStockCarda(stockCard);
            
           // return entity ;
        }

        private IQueryable<StockViewModel> AllStock ()
        {
            return from entity in context.tbl_Stock
                   select new StockViewModel
                   {
                       stockId = entity.StockId,
                       productId = entity.ProductId,
                       productName = entity.tbl_Product.ProductName,
                       purchaseOrderDetailId = entity.tbl_PurchaseOrderDetail.PurchaseOrderDetailId,
                       stockCode = entity.StockCode,
                       purchaseOrderId = entity.PurchaseOrderId,
                       quantitySold = entity.QuantitySold,
                       quantitySupplied = entity.QuantitySupplied,
                       supplyDate = DateTime.Now,
                       costPerItem = entity.CostPerItem,                      
                       sellingPrice = entity.SellingPrice,
                       branchId = entity.BranchId,
                       branchName = entity.tbl_Branch.BranchName, 
                     //  section = entity.tbl_Section.Section,
                       deliveryDate = DateTime.Now,
                       isActive = entity.IsActive,
                       isSoldOut = entity.IsSoldOut,
                       createdOn = DateTime.Now,
                       createdBy = "admin",
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<StockViewModel> GetAllStock ()
        {
            var data = AllStock();
            return data.ToList();
        }

        public void AddStock( OrderDetailViewModel stock)
        {

        }



        public IQueryable<StockViewModel> GetStockById (int id)
        {
            var data = AllStock().Where(c => c.stockId == id);
            return data;
        }

        public bool UpdateStock (StockViewModel entity)
        {
            var data = (from d in context.tbl_Stock where d.StockId == entity.stockId select d).SingleOrDefault();
            if(data != null)
            {
                data.StockId = entity.stockId;
                data.ProductId = entity.productId;
                data.PurchaseOrderDetailId = entity.purchaseOrderDetailId;
                data.StockCode = entity.stockCode;
                data.PurchaseOrderId = entity.purchaseOrderId;
                data.QuantitySold = entity.quantitySold;
                data.QuantitySupplied = entity.quantitySupplied;
                data.SupplyDate = DateTime.Now;
                data.CostPerItem = entity.costPerItem;               
                data.SellingPrice = entity.sellingPrice;
                data.BranchId = entity.branchId;               
                data.DeliveryDate = DateTime.Now;
                data.IsActive = entity.isActive;
                data.IsSoldOut = entity.isSoldOut;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            };
            return context.SaveChanges() > 0;
        }

        //public List<StockOrder> StockPurchase(string vent)
        //{
        //    var result = (from x in GetAllPurchaseOrder()
        //                  join z in context.tbl_PurchaseOrderDetail on p.productId equals s.ProductId
        //                  where p.productName.ToLower().Contains(search.ToLower()) || p.productBarCode.ToLower().Contains(search.ToLower())
        //                  select new ProductFilter
        //                  {
        //                      Price = s.SellingPrice,
        //                      ProductId = s.ProductId,
        //                      ProductName = p.productName + " " + p.size,
        //                      QtyLeft = s.QuantitySupplied - s.QuantitySold,
        //                      StockId = s.StockId
        //                  });
        //    return result.Where(c => c.QtyLeft > 0).ToList();
        //}

    }
}
