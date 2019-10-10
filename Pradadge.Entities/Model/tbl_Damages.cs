namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Damages
    {
        [Key]
        public int DamagesId { get; set; }

        public int? ProductId { get; set; }

        public int? StockId { get; set; }

        public decimal? QuantityDamaged { get; set; }

        public DateTime? DamagedDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [StringLength(550)]
        public string Reason { get; set; }

        public virtual tbl_Product tbl_Product { get; set; }

        public virtual tbl_Stock tbl_Stock { get; set; }
    }
}
