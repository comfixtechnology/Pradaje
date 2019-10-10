namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Company()
        {
            tbl_ReferenceManager = new HashSet<tbl_ReferenceManager>();
        }

        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(250)]
        public string CompanyAddress { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyLogo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ReferenceManager> tbl_ReferenceManager { get; set; }
    }
}
