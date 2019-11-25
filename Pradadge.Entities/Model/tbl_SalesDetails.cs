namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SalesDetails
    {
        [Key]
        public int SalesDetailsId { get; set; }

        public int SalesTypeId { get; set; }

        public int ProductId { get; set; }

        public int StockId { get; set; }

        public int? CustomerId { get; set; }

        public decimal Quantity { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal AmountRecieved { get; set; }

        public DateTime SalesDate { get; set; }

        [Required]
        [StringLength(50)]
        public string SuppliedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string BatchNo { get; set; }

        public int BranchId { get; set; }

        public int PaymentId { get; set; }

        public virtual tbl_Branch tbl_Branch { get; set; }

        public virtual tbl_Customer tbl_Customer { get; set; }

        public virtual tbl_Payment tbl_Payment { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }

        public virtual tbl_Stock tbl_Stock { get; set; }
    }
}
