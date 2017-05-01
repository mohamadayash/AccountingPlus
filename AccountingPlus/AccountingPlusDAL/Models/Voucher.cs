using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Voucher
    {
        [Key]
        public String UserContactRefId { set; get; }

        [ForeignKey("User")]
        public String UserRefId { set; get; }

        [ForeignKey("UserOfContact")]
        public String ContactRefId { set; get; }

        public virtual User UserOfContact {set;get;}

        public virtual User User { set; get; }
    }
}
