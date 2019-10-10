using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Business
{
    public class DamagesViewModel
    {
        public int damagesId { get; set; }

        public int? productId { get; set; }

        public string productName { get; set; }

        public int? stockId { get; set; }

        public string stockCode { get; set; }

        public decimal? quantityDamaged { get; set; }

        public DateTime? damagedDate { get; set; }

        public DateTime? createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }

        public string reason { get; set; }

    }
}
