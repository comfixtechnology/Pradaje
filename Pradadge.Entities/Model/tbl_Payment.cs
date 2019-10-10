namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Payment()
        {
            tbl_SalesDetails = new HashSet<tbl_SalesDetails>();
        }

        [Key]
        public int PaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string BatchNo { get; set; }

        public int CustomerId { get; set; }

        public int SalesTypeId { get; set; }

        public int PaymentModeId { get; set; }

        public int? TransactionStatusId { get; set; }

        public decimal RecievedAmount { get; set; }

        public decimal ActualAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual tbl_PaymentMode tbl_PaymentMode { get; set; }

        public virtual tbl_SalesType tbl_SalesType { get; set; }

        public virtual tbl_TransactionStatus tbl_TransactionStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SalesDetails> tbl_SalesDetails { get; set; }
    }
}
