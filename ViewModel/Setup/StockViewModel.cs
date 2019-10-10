using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.ViewModel.Setup
{
    public class StockViewModel
    {
        public int stockId { get; set; }

        public int purchaseOrderDetailId { get; set; }

        public string stockCode { get; set; }

        public int purchaseOrderId { get; set; }

        //public string purchaseOrderCode { get; set; }

        public int productId { get; set; }

        public string productName { get; set; }

        public decimal quantitySold { get; set; }

        public decimal quantitySupplied { get; set; }

        public DateTime supplyDate { get; set; }

        public decimal costPerItem { get; set; }

        public decimal sellingPrice { get; set; }

        public int? sectionId { get; set; }

        public string section { get; set; }

        public int? branchId { get; set; }

        public string branchName { get; set; }

        public DateTime deliveryDate { get; set; }

        public bool isActive { get; set; }

        public bool isSoldOut { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string modifiedBy { get; set; }

        public decimal? lenght { get; set; }

        public decimal? width { get; set; }

        public decimal? base_height { get; set; }

        public string uom { get; set; }

        public string size
        {
            get
            {
                var d = Convert.ToInt32(width);
                return ((lenght > 0 && width > 0) ? (Convert.ToInt32(width).ToString() + "x" + Convert.ToInt32(lenght).ToString() + (base_height > 0 ? "x" + Convert.ToInt32(base_height).ToString() : "") + uom) : width.ToString() + uom);
            }
        }
    }

    //public class StockOrder
    //{
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public decimal Price { get; set; }
    //    public decimal QtyBought { get; set; }
    //    public int PurchaseOrderId { get; set; }
    //    public string PurchaseOrderCode { get; set; }
    //}
}
