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
    public class SalesDetailRepository : ISalesDetailRepository
    {
        private PradadgeContext context;
        private IReferenceManagerRepository reference;
        private IStockCardRepositorys card;
        private IStockRepositorys stock;
        private IPaymentRepository payment;
        public SalesDetailRepository (PradadgeContext context,
            IReferenceManagerRepository reference,
            IStockCardRepositorys card,
            IStockRepositorys stock,
            IPaymentRepository payment)
        {
            this.context = context;
            this.reference = reference;
            this.stock = stock;
            this.card = card;
            this.payment = payment;
        }

        public bool SaleProduct (List<SalesDetailsViewModel> orders)
        {
            var result = false;
            foreach (var item in orders)
            {
                var existingStock = context.tbl_Stock.Where(s => s.ProductId == item.productId).FirstOrDefault();
                if (existingStock != null)
                {
                    existingStock.QuantitySupplied -= item.quantity;
                }
                
                if (context.SaveChanges() > 0)
                {
                    AddSalesDetails(item);
                    var stockCard = new StockCardViewModel
                    {
                        dateRecieved = existingStock.DeliveryDate,
                        quantityRecieved = existingStock.QuantitySupplied,
                        //quantityRemaining = existingStock.QuantitySupplied - existingStock.QuantitySold,
                        stockId = existingStock.StockId,
                        createdOn = existingStock.CreatedOn,
                        createdBy = existingStock.CreatedBy,
                        lastDateUpdated = DateTime.Now

                    };
                    card.AddStockCarda(stockCard);
                    result = true;
                }
                else
                {
                    return false;
                }
                
            }
            return result;

        }

        public void AddSalesDetails (SalesDetailsViewModel entity)
        {
            var data = new tbl_SalesDetails
            {
                SalesDetailsId = entity.salesDetailsId,
                SalesTypeId = entity.salesTypeId,
                ProductId = entity.productId,
                StockId = entity.stockId,
                CustomerId = entity.customerId,
                Quantity = entity.quantity,
                SalesPrice = entity.salesPrice,
                AmountRecieved = entity.amountRecieved,
                SuppliedBy = entity.suppliedBy,
                SalesDate = entity.salesDate,
                PaymentId = entity.paymentId,
                BatchNo = reference.ConfirmReferenceNo((int)ReferenceTypesEnum.Invoice, 1),
                BranchId = entity.branchId
            };

            context.tbl_SalesDetails.Add(data);
            //context.SaveChanges();

            var pay = new PaymentViewModel
            {
                batchNo = data.BatchNo,
                recievedAmount = data.AmountRecieved,
                actualAmount = data.tbl_Payment.ActualAmount,
                paymentDate = data.SalesDate,
                paymentModeId = data.tbl_Payment.PaymentModeId,
                paymentMode = data.tbl_Payment.tbl_PaymentMode.PaymentMode,
                transactionStatus = data.tbl_Payment.tbl_TransactionStatus.TransactionStatus,
                transactionStatusId = data.tbl_Payment.TransactionStatusId,
                createdBy = data.tbl_Payment.CreatedBy,
                createdOn = data.tbl_Payment.CreatedOn,

            };
            payment.AddPayments(pay);
            //return entity;
        }

        private IQueryable<SalesDetailsViewModel> AllSalesDetails ()
        {
            return from entity in context.tbl_SalesDetails select new SalesDetailsViewModel
            {
                salesDetailsId = entity.SalesDetailsId,
                salesTypeId = entity.SalesTypeId,
                salesType = context.tbl_SalesType.FirstOrDefault(x=> x.SalesTypeId == entity.SalesTypeId).SalesType,
                productId = entity.ProductId,
                productName = entity.tbl_Product.ProductName,
                stockId = entity.StockId,
                customerId = entity.CustomerId,
                firstName = entity.tbl_Customer.FirstName,
                lastName = entity.tbl_Customer.LastName,
                phoneNo = entity.tbl_Customer.PhoneNo,
                quantity = entity.Quantity,
                salesPrice = entity.SalesPrice,
                amountRecieved = entity.AmountRecieved,
                suppliedBy = entity.SuppliedBy,
                salesDate = entity.SalesDate,
                paymentId = entity.PaymentId,
                batchNo = reference.ConfirmReferenceNo((int)ReferenceTypesEnum.Invoice, 1),
                branchId = entity.BranchId,
                branchName = entity.tbl_Branch.BranchName
            };                          
        }

        public IEnumerable<SalesDetailsViewModel> GetAllSalesDetails ()
        {
            var data = AllSalesDetails();
            return data.ToList();
        }

        public IQueryable<SalesDetailsViewModel> GetSalesDetailsById (int id)
        {
            var data = AllSalesDetails().Where(c => c.salesDetailsId == id);
            return data;
        }

        public bool UpdateSalesDetails (SalesDetailsViewModel entity)
        {
            var data = (from d in context.tbl_SalesDetails where d.SalesDetailsId == entity.salesDetailsId select d).SingleOrDefault();
            if(data != null)
            {
                data.SalesDetailsId = entity.salesDetailsId;
                data.SalesTypeId = entity.salesTypeId;
                data.ProductId = entity.productId;
                data.StockId = entity.stockId;
                data.CustomerId = entity.customerId;
                data.Quantity = entity.quantity;
                data.SalesPrice = entity.salesPrice;
                data.AmountRecieved = entity.amountRecieved;
                data.SuppliedBy = entity.suppliedBy;
                data.SalesDate = DateTime.Now;
                data.PaymentId = entity.paymentId;
                data.BatchNo = entity.batchNo;
                data.BranchId = entity.branchId;
            }               
            return context.SaveChanges() > 0;

        }
    }
}
