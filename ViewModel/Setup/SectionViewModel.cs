using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class SectionViewModel
    {
        public int sectionId { get; set; }

        public string section { get; set; }

        public bool? isActive { get; set; }

        public string createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public string modifiedBy { get; set; }

        public DateTime? modifiedOn { get; set; }
    }
}
