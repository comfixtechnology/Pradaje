using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class SalesDetailsViewModel
    {
        public int salesDetailsId { get; set; }

        public int paymentId { get; set; }

        public string BatchNo { get; set; }

        public int salesTypeId { get; set; }

        public string salesType { get; set; }

        public int productId { get; set; }

        public string productName { get; set; }
         
        public int stockId { get; set; }

        public decimal quantitySupplied { get; set;}

        public int? customerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string customerName { get; set; }

        public string phoneNo { get; set; }

        public decimal quantity { get; set; }

        public decimal salesPrice { get; set; }

        public decimal? amountRecieved { get; set; }

        public string suppliedBy { get; set; }

        public DateTime salesDate { get; set; }
      
        public int branchId { get; set; }

        public string branchName { get; set; }
    }
}
