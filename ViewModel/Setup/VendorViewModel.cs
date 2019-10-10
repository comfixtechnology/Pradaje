using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class VendorViewModel
    {
        public int vendorId { get; set; }

        public string vendor { get; set; }

        public string address { get; set; }

        public string phoneNo { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }

        public bool isActive { get; set; }
    }
}
