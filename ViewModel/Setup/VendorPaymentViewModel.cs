using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class VendorPaymentViewModel
    {
        public int vendorPaymentId { get; set; }

        public int vendorId { get; set; }

        public string vendor { get; set; }

        public int? purchaseOrderId { get; set; }

        public string purchaseOrderCode { get; set; }

        public int? purchaseOrderDetailId { get; set; }

        public string productName { get; set; }

        public decimal quantity { get; set; }

        public decimal costPrice { get; set; }

        public string invoiceNo { get; set; }

        public decimal invoiceTotalCost { get; set; }

        public decimal amountAlreadyPaid { get; set; }

        public decimal balance { get; set; }

        public decimal amountToPay { get; set; }

        public int paymentModeId { get; set; }

        public string paymentMode { get; set; }

        public DateTime paymentDate { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }
    }
}
