namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Stock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Stock()
        {
            tbl_Damages = new HashSet<tbl_Damages>();
            tbl_SalesDetails = new HashSet<tbl_SalesDetails>();
            tbl_StockCard = new HashSet<tbl_StockCard>();
        }

        [Key]
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public int? PurchaseOrderDetailId { get; set; }

        [Required]
        [StringLength(50)]
        public string StockCode { get; set; }

        public int PurchaseOrderId { get; set; }

        public decimal QuantitySold { get; set; }

        public decimal QuantitySupplied { get; set; }

        public DateTime SupplyDate { get; set; }

        public decimal CostPerItem { get; set; }

        public decimal SellingPrice { get; set; }

        public int? BranchId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsSoldOut { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        public virtual tbl_Branch tbl_Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Damages> tbl_Damages { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }

        public virtual tbl_PurchaseOrder tbl_PurchaseOrder { get; set; }

        public virtual tbl_PurchaseOrderDetail tbl_PurchaseOrderDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SalesDetails> tbl_SalesDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_StockCard> tbl_StockCard { get; set; }
    }
}
