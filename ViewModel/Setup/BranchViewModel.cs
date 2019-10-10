using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class BranchViewModel
    {
        public int branchId { get; set; }

        public string branchName { get; set; }

        public int? stateId { get; set; }

        public string stateName { get; set; }

        public int? countryId { get; set; }

        public string countryName { get; set; }

        public string contactPerson { get; set; }

        public string branchAddress { get; set; }

        public string phoneNo { get; set; }

        public string email { get; set; }

        public bool? isStore { get; set; }
                     
        public bool? isWarehouse { get; set; }

        public bool? isActive { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }
    }
}
