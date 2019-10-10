using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class PurchaseOrderViewModel
    {
        public int purchaseOrderId { get; set; }

        public string purchaseOrderCode { get; set; }

        public DateTime? orderedDate { get; set; }

        public List<OrderDetailViewModel> details { get; set; }

        public int? vendorId { get; set; }

        public string vendor { get; set; }

        public bool isActive { get; set; }

        public bool IsRecieved { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime modifiedOn { get; set; }

        public string modifiedBy { get; set; }
        public bool fullyReceived { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int purchaseOrderDetailId { get; set; }
        public int purchaseOrderId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal quantity { get; set; }
        public decimal costPrice { get; set; }
        public decimal? sellingPrice { get; set; }
        public bool IsRecieved { get; set; }
    }
}
