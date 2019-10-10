using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
  public  class BanksViewModel
    {
        public int bankId { get; set; }
        
        public string bankName { get; set; }

        public bool isActive { get; set; }

    }

    public class BanksRequestModel: GeneralModel
    {
        public int bankId { get; set; }

        public string bankName { get; set; }

        public bool isActive { get; set; }
    }
}
