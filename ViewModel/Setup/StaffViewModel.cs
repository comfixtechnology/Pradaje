using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class StaffViewModel
    {
        public int staffId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string otherName { get; set; }

        public string staffName { get { return firstName + " " + lastName + " " + otherName; } }

        public string phoneNo { get; set; }

        public string address { get; set; }

        public string email { get; set; }

        public string alternativePhoneNo { get; set; }

        public string alternativeEmail { get; set; }

        public string designation { get; set; }

        public bool? isActive { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime modifiedOn { get; set; }

        public string modifiedBy { get; set; }
    }
}
