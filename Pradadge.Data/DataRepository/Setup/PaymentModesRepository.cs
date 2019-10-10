using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    public class PaymentModesRepository : IPaymentModesRepository
    {
        private PradadgeContext context;
        public PaymentModesRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public PaymentModeViewModel AddPaymentMode (PaymentModeViewModel entity)
        {
            var data = new tbl_PaymentMode
            {
                 
                PaymentModeId = entity.paymentModeId,
                PaymentMode = entity.paymentMode,
                IsActive = entity.isActive,
                RequiredReferenceNo = entity.requiredReferenceNo,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

            context.tbl_PaymentMode.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<PaymentModeViewModel> AllPaymentMode()
        {
            return from entity in context.tbl_PaymentMode
                   select new PaymentModeViewModel
                   {
                       paymentModeId = entity.PaymentModeId,
                       paymentMode = entity.PaymentMode,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       requiredReferenceNo = entity.RequiredReferenceNo,
                       createdBy = entity.CreatedBy,
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<PaymentModeViewModel> GetAllPaymentModes()
        {
            var data = AllPaymentMode();
            return data.ToList();
        }

        public IQueryable<PaymentModeViewModel> GetPaymentModeById (int id)
        {
            var data = AllPaymentMode().Where(c => c.paymentModeId == id);
            return data;
        }

        public bool UpdatePaymentModeDetails (PaymentModeViewModel entity)
        {
            var data = (from d in context.tbl_PaymentMode where d.PaymentModeId == entity.paymentModeId select d).SingleOrDefault();
            if(data != null)
            {
                //PaymentModeId = entity.PaymentModeId,
                data.PaymentMode = entity.paymentMode;
                data.IsActive = entity.isActive;
                data.ModifiedOn = DateTime.Now;
                data.RequiredReferenceNo = entity.requiredReferenceNo;
                data.ModifiedBy = "admin";
            };
            return context.SaveChanges() > 0;
        }
    }
}

