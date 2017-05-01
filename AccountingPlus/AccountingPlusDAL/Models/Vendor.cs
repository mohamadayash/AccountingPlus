using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Vendor
    {
        [Key]
        public Guid VendorRefId { set; get; }

        public String VendorName { set; get; }

        [ForeignKey("Account")]
        public Guid AccountRefId { set; get; }

        public String VendorPhone { set; get; }

        public String VendorAddress { set; get; }

        [NotMapped]
        public String AccountNumber
        {
            get
            {
                return this.Account.AccountNumber;
            }
        }

        public virtual Account Account { set; get; }
    }
}
