namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_PurchaseOrder()
        {
            tbl_PurchaseOrderDetail = new HashSet<tbl_PurchaseOrderDetail>();
            tbl_Stock = new HashSet<tbl_Stock>();
            tbl_VendorPayment = new HashSet<tbl_VendorPayment>();
        }

        [Key]
        public int PurchaseOrderId { get; set; }

        [StringLength(50)]
        public string PurchaseOrderCode { get; set; }

        public DateTime? OrderedDate { get; set; }

        public int? VendorId { get; set; }

        public bool IsActive { get; set; }

        public bool FullyReceived { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string ModifiedBy { get; set; }

        public virtual tbl_Vendor tbl_Vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PurchaseOrderDetail> tbl_PurchaseOrderDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Stock> tbl_Stock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VendorPayment> tbl_VendorPayment { get; set; }
    }
}
