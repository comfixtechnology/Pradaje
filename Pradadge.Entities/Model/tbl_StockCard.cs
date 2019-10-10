namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_StockCard
    {
        [Key]
        public int StockCardId { get; set; }

        public int StockId { get; set; }

        public decimal QuantityRecieved { get; set; }

        public decimal QuantitySold { get; set; }

        public DateTime DateRecieved { get; set; }

        public DateTime LastDateUpdated { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string CreatedBy { get; set; }

        public virtual tbl_Stock tbl_Stock { get; set; }
    }
}
