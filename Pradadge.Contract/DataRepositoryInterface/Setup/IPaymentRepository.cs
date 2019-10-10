using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentViewModel> GetAllPayments();
        PaymentViewModel AddPayment(PaymentViewModel entity);
        IQueryable<PaymentViewModel> GetPaymentById(int id);
        bool UPdatePaymentDetails(PaymentViewModel entity);
    }
}
