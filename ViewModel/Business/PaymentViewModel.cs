using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class PaymentViewModel
    {
        public int paymentId { get; set; }

        public string batchNo { get; set; }

        public int salesTypeId { get; set; }

        public int salesType { get; set; }

        public int paymentModeId { get; set; }

        public int paymentMode { get; set; }

        public int? transactionStatusId { get; set; }

        public int? transactionStatus { get; set; }

        public decimal recievedAmount { get; set; }

        public decimal actualAmount { get; set; }

        public DateTime paymentDate { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }
    }
}
