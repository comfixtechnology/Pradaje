namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_VendorPayment
    {
        [Key]
        public int VendorPaymentId { get; set; }

        public int VendorId { get; set; }

        public int? PurchaseOrderId { get; set; }

        public int? PurchaseOrderDetailId { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        public decimal InvoiceTotalCost { get; set; }

        public decimal AmountAlreadyPaid { get; set; }

        public decimal Balance { get; set; }

        public decimal AmountToPay { get; set; }

        public int PaymentModeId { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual tbl_PaymentMode tbl_PaymentMode { get; set; }

        public virtual tbl_PurchaseOrder tbl_PurchaseOrder { get; set; }

        public virtual tbl_PurchaseOrderDetail tbl_PurchaseOrderDetail { get; set; }

        public virtual tbl_Vendor tbl_Vendor { get; set; }
    }
}
