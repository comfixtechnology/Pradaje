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
    public class TransactionStatusRepositorys : ITransactionStatusRepositorys
    {
        private PradadgeContext context;
        public TransactionStatusRepositorys (PradadgeContext context)
        {
            this.context = context;
        }

        public TransactionStatusViewModel AddTransactionStatus (TransactionStatusViewModel entity)
        {
            var data = new tbl_TransactionStatus
            {
                TransactionStatusId = entity.transactionStatusId,
                TransactionStatus = entity.transactionStatus
            };
            context.tbl_TransactionStatus.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<TransactionStatusViewModel> AllTransactionStatus ()
        {
            return from entity in context.tbl_TransactionStatus
                   select new TransactionStatusViewModel
                   {
                       transactionStatusId = entity.TransactionStatusId,
                       transactionStatus = entity.TransactionStatus
                   };
        }

        public IEnumerable<TransactionStatusViewModel> GetAllTransactionStatus()
        {
            var data = AllTransactionStatus();
            return data.ToList();
        }

        public IQueryable<TransactionStatusViewModel> GetTransactionStatusById (int id)
        {
            var data = AllTransactionStatus().Where(c => c.transactionStatusId == id);
            return data;
        }

        public bool UpdateTransaction (TransactionStatusViewModel entity)
        {
            var data = (from d in context.tbl_TransactionStatus where d.TransactionStatusId == entity.transactionStatusId select d).SingleOrDefault();
            if(data != null)
            {
                data.TransactionStatusId = entity.transactionStatusId;
                data.TransactionStatus = entity.transactionStatus;
            };
            return context.SaveChanges() > 0;
        }
    }
}
