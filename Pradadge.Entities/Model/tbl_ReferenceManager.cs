namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ReferenceManager
    {
        [Key]
        public int ReferenceManagerId { get; set; }

        [Required]
        [StringLength(20)]
        public string ReferenceNo { get; set; }

        public int SeriaNo { get; set; }

        public int ReferenceType { get; set; }

        public bool ValidReference { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CompanyId { get; set; }

        public virtual tbl_Company tbl_Company { get; set; }
    }
}
