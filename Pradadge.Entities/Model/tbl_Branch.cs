namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Branch()
        {
            tbl_SalesDetails = new HashSet<tbl_SalesDetails>();
            tbl_Stock = new HashSet<tbl_Stock>();
        }

        [Key]
        public int BranchId { get; set; }

        [Required]
        [StringLength(250)]
        public string BranchName { get; set; }

        public int? StateId { get; set; }

        public int? CountryId { get; set; }

        [Required]
        [StringLength(250)]
        public string ContactPerson { get; set; }

        [StringLength(250)]
        public string BranchAddress { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool? IsStore { get; set; }

        public bool? IsWarehouse { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string ModifiedBy { get; set; }

        public virtual tbl_Country tbl_Country { get; set; }

        public virtual tbl_State tbl_State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SalesDetails> tbl_SalesDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Stock> tbl_Stock { get; set; }
    }
}
