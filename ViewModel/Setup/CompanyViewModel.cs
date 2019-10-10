using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class CompanyViewModel
    {
        public int companyId { get; set; }

        public string companyName { get; set; }

        public string companyAddress { get; set; }

        public string phoneNo { get; set; }

        public string email { get; set; }

        public string website { get; set; }

        public bool? isActive { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime modifiedOn { get; set; }

        public string modifiedBy { get; set; }

        public string companyLogo { get; set; }
    }
}
