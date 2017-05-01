using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerRefId { set; get; }

        public String CustomerName { set; get; }

        [ForeignKey("Account")]
        public Guid AccountRefId { set; get; }

        public String CustomerPhone { set; get; }

        public String CustomerAddress { set; get; }

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
