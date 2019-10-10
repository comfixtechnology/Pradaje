namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PaymentMode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_PaymentMode()
        {
            tbl_Payment = new HashSet<tbl_Payment>();
            tbl_VendorPayment = new HashSet<tbl_VendorPayment>();
        }

        [Key]
        public int PaymentModeId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMode { get; set; }

        public bool IsActive { get; set; }

        public bool RequiredReferenceNo { get; set; }
        
        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Payment> tbl_Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VendorPayment> tbl_VendorPayment { get; set; }
    }
}
