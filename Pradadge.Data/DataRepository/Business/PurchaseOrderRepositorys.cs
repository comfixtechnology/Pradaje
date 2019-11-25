using Pradadge.Common.Enum;
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
    public class PurchaseOrderRepositorys : IPurchaseOrderRepositorys
    {
        private PradadgeContext context;
        private IReferenceManagerRepository reference;
        private IStockCardRepositorys Card;
        private IStockRepositorys stock;
        public PurchaseOrderRepositorys (PradadgeContext context,
            IStockRepositorys stock,
            IReferenceManagerRepository reference, 
            IStockCardRepositorys Card)
        {
            this.context = context;
            this.reference = reference;
            this.Card = Card;
            this.stock = stock;
        }

        public bool ReceiveAllOrders(List<OrderDetailViewModel> orders)
        {
            bool result = false;
            foreach (var item in orders)
            {
                var order = context.tbl_PurchaseOrderDetail
                                     .Where(c => c.PurchaseOrderDetailId == item.purchaseOrderDetailId)
                                     .FirstOrDefault();
                order.IsRecieved = true;
                StockViewModel stork = AddStockItems(item, order);
                stock.AddStockEntries(stork);

                //var existingStock = context.tbl_Stock.Where(s => s.ProductId == item.productId).FirstOrDefault();
                //if (existingStock != null)
                //{
                //    existingStock.QuantitySupplied += item.quantity;
                //}
                //else
                //{
                //    StockViewModel stork = AddStockItems(item, order);
                //    stock.AddStockEntries(stork);
                //}

                if (context.SaveChanges() > 0)
                {
                    UpdateOrderifFullyReceived(item.purchaseOrderId);
                    result = true;
                }
                else
                    return false;
            }
            return result;
        }

        public OrderDetailViewModel RecieveOrder(OrderDetailViewModel entity)
        {
            var order = context.tbl_PurchaseOrderDetail
                        .Where(c => c.PurchaseOrderDetailId == entity.purchaseOrderDetailId)
                        .FirstOrDefault();
            order.IsRecieved = true;

            StockViewModel stork = AddStockItems(entity, order);
            stock.AddStockEntries(stork);

            //var existingStock = context.tbl_Stock.Where(s => s.ProductId == entity.productId).FirstOrDefault();
            //if (existingStock != null)
            //{
            //    existingStock.QuantitySupplied += entity.quantity;
            //}
            //else
            //{
            //    StockViewModel stork = AddStockItems(entity, order);
            //    stock.AddStockEntries(stork);
            //}

            if (context.SaveChanges() > 0)
            {
                UpdateOrderifFullyReceived(entity.purchaseOrderId);
                return SetOrderDetails(entity, order);
            }
            else
            {
                return null;
            }
        }

        private StockViewModel AddStockItems(OrderDetailViewModel entity, tbl_PurchaseOrderDetail order)
        {
            return new StockViewModel
            {
                branchId = 14,
                supplyDate = DateTime.Now,
                productName = order.tbl_Product.ProductName,
                sellingPrice = (decimal)entity.sellingPrice,
                productId = order.ProductId,
                isSoldOut = false,
                isActive = true,
                costPerItem = order.CostPrice,
                quantitySupplied = entity.quantity,
                deliveryDate = DateTime.Now,
                createdBy = "admin",
                createdOn = DateTime.Now,
                purchaseOrderDetailId = order.PurchaseOrderDetailId,
                purchaseOrderId = order.PurchaseOrderId,
                stockCode = reference.ConfirmReferenceNo((int)ReferenceTypesEnum.Stock, 1)

            };

        }

        private StockCardViewModel AddStockcardItems (OrderDetailViewModel entity, tbl_PurchaseOrderDetail order)
        {
            return new StockCardViewModel
            {
                dateRecieved = DateTime.Now,
                quantityRecieved = order.Quantity,
                //quantityRemaining = data.quantityRemaining,
                stockId = context.tbl_Stock.FirstOrDefault(s=>s.ProductId == entity.productId).StockId,
                createdOn = DateTime.Now,
                //createdBy = order.CreatedBy,
                lastDateUpdated = DateTime.Now

            };
            //Card.AddStockCarda(stockCard);
        }

        private  void UpdateOrderifFullyReceived(int purchaseOrderId)
        {
           var order= context.tbl_PurchaseOrderDetail.Where(p => p.PurchaseOrderId == purchaseOrderId && p.IsRecieved == false);
            if (!order.Any())
            {
               var purOrder = context.tbl_PurchaseOrder.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderId);
                purOrder.FullyReceived = true;
                context.SaveChanges(); 
            }
        }

        private static OrderDetailViewModel SetOrderDetails(OrderDetailViewModel entity, tbl_PurchaseOrderDetail order)
        {
            var result = new OrderDetailViewModel
            {
                costPrice = order.CostPrice,
                sellingPrice = entity.sellingPrice,
                IsRecieved = order.IsRecieved,
                productId = order.ProductId,
                productName = order.tbl_Product.ProductName,
                purchaseOrderDetailId = order.PurchaseOrderDetailId,
                purchaseOrderId = order.PurchaseOrderId,
                quantity = order.Quantity,
                 
            };
            return result;
        }

        public void RecieveOrder(List<OrderDetailViewModel> entity)
        {
             List<tbl_PurchaseOrderDetail> lstOrder = new List<tbl_PurchaseOrderDetail>();
            foreach(var item in entity)
            {
                var order = context.tbl_PurchaseOrderDetail.Where(c => c.PurchaseOrderDetailId == item.purchaseOrderDetailId).FirstOrDefault();
                order.IsRecieved = true;
                
            }

            

        }

        public PurchaseOrderViewModel AddPurchaseOrder(PurchaseOrderViewModel entity)
        {

            var data = new tbl_PurchaseOrder
            {
                PurchaseOrderId = entity.purchaseOrderId,
                PurchaseOrderCode = reference.ConfirmReferenceNo((int)ReferenceTypesEnum.PurchaseOrder, 1),
                OrderedDate = DateTime.Now,
                VendorId = entity.vendorId,
                IsActive = entity.isActive,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

                context.tbl_PurchaseOrder.Add(data);

                List<tbl_PurchaseOrderDetail> lstdetails = new List<tbl_PurchaseOrderDetail>(); ;
                foreach (var item in entity.details)
                {
                    if (item.quantity > 0)
                    {
                        var details = new tbl_PurchaseOrderDetail
                        {
                            CostPrice = item.costPrice,
                            Quantity = item.quantity,
                            PurchaseOrderId = data.PurchaseOrderId,
                            ProductId = item.productId,
                            ModifiedBy = entity.createdBy,
                            ModifiedOn = DateTime.Now,
                            PurchaseOrderDetailId = item.purchaseOrderDetailId,                              
                        };
                        lstdetails.Add(details);
                    }

                }
                context.tbl_PurchaseOrderDetail.AddRange(lstdetails);

            //foreach (var items in entity.details)
            //{

            //var duplicate = context.tbl_PurchaseOrderDetail.Where(c => c.PurchaseOrderDetailId >= 1).SingleOrDefault();
            //if (lstdetails != null) {
            //    //var duplicate = from c in context.tbl_PurchaseOrderDetail
            //    //                join d in context.tbl_Stock on c.PurchaseOrderDetailId equals d.PurchaseOrderDetailId
            //    //                where c.PurchaseOrderDetailId == d.PurchaseOrderDetailId
            //    //                select new tbl_Stock
            //    //                {
            //    //                    ProductId = c.ProductId,
            //    //                    QuantitySupplied = c.Quantity,
            //    //                    SellingPrice = c.CostPrice
            //    //                };

            //    //var duplicate = context.tbl_PurchaseOrderDetail.Where(c => c.PurchaseOrderDetailId >= 1).SingleOrDefault();
            //    var ven = new tbl_Stock
            //    {
            //        ProductId = duplicate.ProductId,
            //        PurchaseOrderDetailId = duplicate.PurchaseOrderDetailId,
            //        QuantitySupplied = duplicate.Quantity,
            //        //SellingPrice 
            //    };

            //    context.tbl_Stock.Add(ven);
            //}               
            ////}
            
            context.SaveChanges();
            return entity;
        }

        public int GetPurchaseOrderRecordId ()
        {
            var record = AllPurchaseOrder().ToList().Max(c => c.purchaseOrderId) + 1;

            return record;
        }

        private decimal GetSellingPrice(int detailId)
        {
            var stock = context.tbl_Stock.Where(s => s.PurchaseOrderDetailId == detailId).SingleOrDefault();
            if (stock != null)
                return stock.SellingPrice;
            else
                return 0;
        }

        private IQueryable<PurchaseOrderViewModel> AllPurchaseOrder()
        {
            return from entity in context.tbl_PurchaseOrder
                   select new PurchaseOrderViewModel
                   {
                       purchaseOrderId = entity.PurchaseOrderId,
                       purchaseOrderCode = entity.PurchaseOrderCode,
                       orderedDate = entity.OrderedDate,
                       vendorId = entity.VendorId,
                       vendor = entity.tbl_Vendor.Vendor,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       createdBy = "admin",
                       modifiedOn = entity.ModifiedOn,
                       modifiedBy = "admin",
                       fullyReceived = entity.FullyReceived,
                       details = context.tbl_PurchaseOrderDetail
                       .Where(c => c.PurchaseOrderId == entity.PurchaseOrderId)
                       .Select(c => new OrderDetailViewModel
                       {
                           costPrice = c.CostPrice,
                           productId = c.ProductId,
                           productName = c.tbl_Product.ProductName,
                           purchaseOrderId = c.PurchaseOrderId,
                           quantity = c.Quantity,
                           purchaseOrderDetailId = c.PurchaseOrderDetailId,
                           IsRecieved = c.IsRecieved ,
                            sellingPrice  = ( context.tbl_Stock
                            .Where(s => s.PurchaseOrderDetailId == c.PurchaseOrderDetailId)
                            .FirstOrDefault().SellingPrice)
        }).ToList()
                   };
        }

        public bool DeleteOrderDetail(OrderDetailViewModel entity)
        {
            var data = context.tbl_PurchaseOrderDetail.SingleOrDefault(d => d.PurchaseOrderDetailId == entity.purchaseOrderDetailId);
            if (data != null)
            {
              context.tbl_PurchaseOrderDetail.Remove(data);
              return  context.SaveChanges() > 0;
            }
            return false;
        }


        //public bool DeletePurchaseOrder(PurchaseOrderViewModel entity, OrderDetailViewModel venz)
        //{
        //    var data = context.tbl_PurchaseOrder.SingleOrDefault(d => d.PurchaseOrderId == entity.purchaseOrderId);
        //    context.tbl_PurchaseOrder.Remove(data);

        //    if (data != null)
        //    {
                
        //        var RmData = context.tbl_PurchaseOrderDetail.Where(x => x.PurchaseOrderDetailId == venz.purchaseOrderDetailId);
        //        context.tbl_PurchaseOrderDetail.RemoveRange(RmData);
        //        return context.SaveChanges() > 0;
        //    }
           
        //    //context.SaveChanges();
        //    return false;
        //}

        public void DeletePurchaseOrder (int id)
        {
            var data = from d in context.tbl_PurchaseOrder
                       join c in context.tbl_PurchaseOrderDetail on d.PurchaseOrderId equals c.PurchaseOrderId
                       where d.PurchaseOrderId == c.PurchaseOrderId
                       select d;
            context.tbl_PurchaseOrder.RemoveRange(data);
            //context.tbl_PurchaseOrderDetail.Remove(data);
        }

        public int GetOrderCode()
        {
            var pOrder = AllPurchaseOrder().Max(c => c.purchaseOrderId);
            var head = pOrder + 1;
                

            return head;
        }

        public IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder()
        {
            var data = AllPurchaseOrder().Where(x=> x.fullyReceived == false).OrderByDescending(x => x.purchaseOrderId);
            return data.ToList();
        }

        public IQueryable<PurchaseOrderViewModel> GetPurchaseOrderById (int id)
        {
            var data = AllPurchaseOrder().Where(c => c.purchaseOrderId == id);
            return data;
        }

        public bool UpdatePurchaseOrder (PurchaseOrderViewModel entity)
        {
            var data = (from d in context.tbl_PurchaseOrder where d.PurchaseOrderId == entity.purchaseOrderId select d).SingleOrDefault();
            if(data != null)
            {
                data.PurchaseOrderId = entity.purchaseOrderId;
                data.PurchaseOrderCode = entity.purchaseOrderCode;
                data.OrderedDate = entity.orderedDate;
                data.VendorId = entity.vendorId;
                data.IsActive = entity.isActive; 
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
                
            };

            var dDatails = context.tbl_PurchaseOrderDetail.Where(p => p.PurchaseOrderId == data.PurchaseOrderId);

            context.tbl_PurchaseOrderDetail.RemoveRange(dDatails);

            List<tbl_PurchaseOrderDetail> lstdetails = new List<tbl_PurchaseOrderDetail>(); ;
            foreach (var item in entity.details)
            {
                if (item.quantity > 0)
                {
                    var details = new tbl_PurchaseOrderDetail
                    {
                        CostPrice = item.costPrice,
                        Quantity = item.quantity,
                        PurchaseOrderId = data.PurchaseOrderId,
                        ProductId = item.productId,
                        ModifiedBy = entity.createdBy,
                        ModifiedOn = DateTime.Now,
                    };
                    lstdetails.Add(details);
                }

            }
            context.tbl_PurchaseOrderDetail.AddRange(lstdetails);

            return context.SaveChanges() > 0;
        }

        public bool UpdatePurchaseOderDetail (OrderDetailViewModel entity)
        {
            var data = (from d in context.tbl_PurchaseOrderDetail where d.PurchaseOrderDetailId == entity.purchaseOrderDetailId select d).SingleOrDefault();
            if (data != null)
            {
                data.PurchaseOrderDetailId = entity.purchaseOrderDetailId;
                data.PurchaseOrderId = entity.purchaseOrderId;
                data.ProductId = entity.productId;
                data.Quantity = entity.quantity;
                data.CostPrice = entity.costPrice;
            }
            return context.SaveChanges() > 0;
        }
    }
}
