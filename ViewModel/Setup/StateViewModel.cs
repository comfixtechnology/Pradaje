using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class StateViewModel
    {

        public int stateId { get; set; }

        public string stateName { get; set; }

        public bool?isActive { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }

        
    }
}
