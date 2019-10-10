using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class ReferenceManagerViewModel
    {
        public int serialNo;

        public int referenceManagerId { get; set; }

        public string referenceManager { get; set; }

        public int referenceType { get; set; }

        public bool validReference { get; set; }

        public DateTime createdOn { get; set; }

        public int companyId { get; set; }

        public string companyName { get; set; }

        //public List<PurchaseOrderViewModel> order { get; set; }
       
        //public int purchaseOrderId { get; set; }

        //public string purchaseOrderCode { get; set; }

        //public DateTime? orderedDate { get; set; }

    }
}
