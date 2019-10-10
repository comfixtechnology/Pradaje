using Pradadge.ViewModel.Business;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IVendorPaymentRepository
    {
        VendorPaymentViewModel AddVendorPayment(VendorPaymentViewModel entity);
        IEnumerable<VendorPaymentViewModel> GetVendorPayment();
        IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder();
        IQueryable<PurchaseOrderViewModel> GetPurchaseOrderById(int id);
        IQueryable<VendorPaymentViewModel> GetVendorPaymentById(int id);
        bool UpdateVendorPayment(VendorPaymentViewModel entity);
    }
}
