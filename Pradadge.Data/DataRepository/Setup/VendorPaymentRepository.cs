using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    public class VendorPaymentRepository: IVendorPaymentRepository
    {
        private IPurchaseOrderRepositorys purchase;
        private PradadgeContext context;
        public VendorPaymentRepository (PradadgeContext context)
        {
            this.context = context;
            this.purchase = purchase;
        }

        public VendorPaymentViewModel AddVendorPayment (VendorPaymentViewModel entity)
        {
            var data = new tbl_VendorPayment
            {
                VendorPaymentId = entity.vendorPaymentId,
                VendorId = entity.vendorId,
                PurchaseOrderId = entity.purchaseOrderId,
                PurchaseOrderDetailId = entity.purchaseOrderDetailId,
                InvoiceNo = entity.invoiceNo,
                InvoiceTotalCost = entity.invoiceTotalCost,
                AmountAlreadyPaid = entity.amountAlreadyPaid,
                AmountToPay = entity.amountToPay,
                Balance = entity.balance,
                PaymentModeId = entity.paymentModeId,
                PaymentDate = entity.paymentDate,
                CreatedBy = "admin",
                CreatedOn = entity.createdOn,
                ModifiedBy = "admin",
                ModifiedOn = entity.modifiedOn
            };

            context.tbl_VendorPayment.Add(data);
            context.SaveChanges();
            return entity;
        }

        public IQueryable<VendorPaymentViewModel> AllVendorPayment()
        {
            return from entity in context.tbl_VendorPayment
                   select new VendorPaymentViewModel
                   {
                       vendorPaymentId = entity.VendorPaymentId,
                       vendorId = entity.VendorId,
                       vendor = entity.tbl_Vendor.Vendor,
                       purchaseOrderId = entity.PurchaseOrderId,
                       purchaseOrderCode = entity.tbl_PurchaseOrder.PurchaseOrderCode,
                       purchaseOrderDetailId = entity.PurchaseOrderDetailId,
                       productName = entity.tbl_PurchaseOrderDetail.tbl_Product.ProductName,
                       quantity = entity.tbl_PurchaseOrderDetail.Quantity,
                       costPrice = entity.tbl_PurchaseOrderDetail.CostPrice,
                       invoiceNo = entity.InvoiceNo,
                       invoiceTotalCost = entity.InvoiceTotalCost,
                       amountAlreadyPaid = entity.AmountAlreadyPaid,
                       amountToPay = entity.AmountToPay,
                       balance = entity.Balance,
                       paymentModeId = entity.PaymentModeId,
                       paymentMode = entity.tbl_PaymentMode.PaymentMode,
                       paymentDate = entity.PaymentDate,
                       createdBy = "admin",
                       createdOn = entity.CreatedOn,
                       modifiedBy = "admin",
                       modifiedOn = entity.ModifiedOn
                   };
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
                           IsRecieved = c.IsRecieved,
                           sellingPrice = (context.tbl_Stock
                            .Where(s => s.PurchaseOrderDetailId == c.PurchaseOrderDetailId)
                            .FirstOrDefault().SellingPrice)
                       }).ToList()
                   };
        }

        public IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder()
        {
            var data = AllPurchaseOrder().Where(x => x.fullyReceived == false).OrderByDescending(x => x.purchaseOrderId);
            return data.ToList();
        }

        public IQueryable<PurchaseOrderViewModel> GetPurchaseOrderById(int id)
        {
            var data = AllPurchaseOrder().Where(c => c.purchaseOrderId == id);
            return data;
        }


        public IEnumerable<VendorPaymentViewModel> GetVendorPayment()
        {
            var data = AllVendorPayment();
            return data.ToList();
        }

        public IQueryable<VendorPaymentViewModel> GetVendorPaymentById(int id)
        {
            var data = AllVendorPayment().Where(c => c.vendorPaymentId == id);
            return data;
        }

        public bool UpdateVendorPayment (VendorPaymentViewModel entity)
        {
            var data = (from c in context.tbl_VendorPayment where c.VendorPaymentId == entity.vendorPaymentId select c).SingleOrDefault();
            if(data != null)
            {
                data.VendorPaymentId = entity.vendorPaymentId;
                data.VendorId = entity.vendorId;
                data.PurchaseOrderId = entity.purchaseOrderId;
                data.PurchaseOrderDetailId = entity.purchaseOrderDetailId;
                data.InvoiceNo = entity.invoiceNo;
                data.InvoiceTotalCost = entity.invoiceTotalCost;
                data.AmountAlreadyPaid = entity.amountAlreadyPaid;
                data.AmountToPay = entity.amountToPay;
                data.Balance = entity.balance;
                data.PaymentModeId = entity.paymentModeId;
                data.PaymentDate = entity.paymentDate;
                data.CreatedBy = "admin";
                data.CreatedOn = entity.createdOn;
                data.ModifiedBy = "admin";
                data.ModifiedOn = entity.modifiedOn;
            }

            return context.SaveChanges() > 0;
        }
    }
}
