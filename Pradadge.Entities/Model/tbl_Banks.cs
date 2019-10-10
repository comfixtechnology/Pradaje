using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Entities.Model
{
    public partial class tbl_Banks
    {

        [Key]
        public int BankId { get; set; }

        [Required]
        [StringLength(50)]
        public string BankName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
