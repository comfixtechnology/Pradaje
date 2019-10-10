namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Product()
        {
            tbl_Damages = new HashSet<tbl_Damages>();
            tbl_PurchaseOrderDetail = new HashSet<tbl_PurchaseOrderDetail>();
            tbl_SalesDetails = new HashSet<tbl_SalesDetails>();
            tbl_Stock = new HashSet<tbl_Stock>();
        }

        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string ProductDescription { get; set; }

        public int? ProductCode { get; set; }

        [StringLength(50)]
        public string ProductBarCode { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? Packing { get; set; }

        public decimal? Width { get; set; }

        public decimal? Lenght { get; set; }

        public decimal? Base_height { get; set; }

        public bool UseDimensionInCalculation { get; set; }

        public int? UnitOfMeasurementId { get; set; }

        public bool ApplyDimension { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? InSquareMeters { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual tbl_Brand tbl_Brand { get; set; }

        public virtual tbl_Category tbl_Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Damages> tbl_Damages { get; set; }

        public virtual tbl_Measurement tbl_Measurement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PurchaseOrderDetail> tbl_PurchaseOrderDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SalesDetails> tbl_SalesDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Stock> tbl_Stock { get; set; }
    }
}
