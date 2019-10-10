using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ITransactionStatusRepositorys
    {
        TransactionStatusViewModel AddTransactionStatus(TransactionStatusViewModel entity);
        IEnumerable<TransactionStatusViewModel> GetAllTransactionStatus();
        IQueryable<TransactionStatusViewModel> GetTransactionStatusById(int id);
        bool UpdateTransaction(TransactionStatusViewModel entity);
    }
}
