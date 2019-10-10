using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IPaymentModesRepository
    {
        IEnumerable<PaymentModeViewModel> GetAllPaymentModes();
        PaymentModeViewModel AddPaymentMode(PaymentModeViewModel entity);
        IQueryable<PaymentModeViewModel> GetPaymentModeById(int id);
        bool UpdatePaymentModeDetails(PaymentModeViewModel entity);
    }
}
