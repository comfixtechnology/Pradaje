using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    public class PaymentRepository : IPaymentRepository
    {
        private PradadgeContext context;
        public PaymentRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public PaymentViewModel AddPayment (PaymentViewModel entity)
        {
            var data = new tbl_Payment
            {
                PaymentId = entity.paymentId,
                ActualAmount = entity.actualAmount,
                BatchNo = entity.batchNo,
                PaymentModeId = entity.paymentModeId,
                PaymentDate = DateTime.Now,
                RecievedAmount = entity.recievedAmount,
                SalesTypeId = entity.salesTypeId,
                TransactionStatusId = entity.transactionStatusId,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

            context.tbl_Payment.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<PaymentViewModel> AllPayment ()
        {
            return from entity in context.tbl_Payment
                   select new PaymentViewModel
                   {
                       paymentId = entity.PaymentId,
                       actualAmount = entity.ActualAmount,
                       batchNo = entity.BatchNo,
                       paymentModeId = entity.PaymentModeId,
                       paymentDate = DateTime.Now,
                       recievedAmount = entity.RecievedAmount,
                       salesTypeId  = entity.SalesTypeId,
                       transactionStatusId = entity.TransactionStatusId,
                       createdOn = DateTime.Now,
                       createdBy = "admin",
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<PaymentViewModel> GetAllPayments ()
        {
            var data = AllPayment();
            return data.ToList();
        }

        public IQueryable<PaymentViewModel> GetPaymentById (int id)
        {
            var data = AllPayment().Where(c => c.paymentId == id);
            return data;
        }

        public bool UPdatePaymentDetails (PaymentViewModel entity)
        {
            var data = (from d in context.tbl_Payment where d.PaymentId == entity.paymentId select d).SingleOrDefault();
            if(data != null)
            {
                data.PaymentId = entity.paymentId;
                data.ActualAmount = entity.actualAmount;
                data.BatchNo = entity.batchNo;
                data.PaymentModeId = entity.paymentModeId;
                data.PaymentDate = DateTime.Now;
                data.RecievedAmount = entity.recievedAmount;
                data.SalesTypeId = entity.salesTypeId;
                data.TransactionStatusId = entity.transactionStatusId;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            };
            return context.SaveChanges() > 0;
        }
    }
}
