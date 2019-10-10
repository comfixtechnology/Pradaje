using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class StockCardViewModel
    {
        public int stockCardId { get; set; }

        public int stockId { get; set; }

        public decimal quantityRecieved { get; set; }

        public decimal quantitySold { get; set; }

        public DateTime dateRecieved { get; set; }

        public DateTime lastDateUpdated { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public decimal quantityRemaining { get{ return quantityRecieved - quantitySold; } }


    }
}
