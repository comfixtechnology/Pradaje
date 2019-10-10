using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge. ViewModel.Setup
{
  public   class ProductViewModel
    {
      
        public int productId { get; set; }

        
        public string productName { get; set; }
       
        public string productDescription { get; set; }

        public int? productCode { get; set; }

        public string productBarCode { get; set; }
         
        public int? brandId { get; set; }

        public string brandName { get; set; }

        public int? categoryId { get; set; }

        public string categoryName { get; set; }

        public decimal? lenght { get; set; }

        public decimal? width { get; set; }

        public decimal? base_height { get; set; }

        //public decimal? netWeight { get; set; }

        public int? packing { get; set; }

        public string size
        {
            get
            {
                var d = Convert.ToInt32(width);
                return (( lenght > 0 && width  > 0 )? (Convert.ToInt32(width).ToString() + "x" + Convert.ToInt32(lenght).ToString() + (base_height > 0 ? "x" + Convert.ToInt32(base_height).ToString()  : "") + uom) : width.ToString() + uom);
            }
        }

        //public string weightClass { get; set; }

        public int? unitOfMeasurementId { get; set; }

        public string uom { get; set; }

        public bool applyDimension { get; set; }

        public bool isActive { get; set; }

        public DateTime? createdOn { get; set; }
       
        public string createdBy { get; set; }
       
        public DateTime? modifiedOn { get; set; }
        
        public string modifiedBy { get; set; }

        public bool useDimensionInCalculation { get; set; }

        public decimal? inSquareMeters { get; set; }
    }

    public class ProductFilter {
        public bool applyDimension { get; set; }

        public int productId { get; set; }
        public string productName { get; set; }
        public decimal? price { get; set; }
        public decimal? qtyLeft { get; set; }
        public int? stockId { get; set; }
        public decimal? count { get; set; }
        public string productNameandQty { get { return $"{ productName } available qty { count.ToString()}"; }  }

        public DateTime? deliveryDate { get; set; }
    }


}
