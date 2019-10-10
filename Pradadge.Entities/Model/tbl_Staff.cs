namespace Pradadge.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string OtherName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string AlternativePhoneNo { get; set; }

        [StringLength(50)]
        public string AlternativeEmail { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        [StringLength(250)]
        public string ModifiedBy { get; set; }
    }
}
