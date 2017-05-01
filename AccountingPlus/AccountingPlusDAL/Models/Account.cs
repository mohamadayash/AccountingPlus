using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Account
    {
        [Key]
        public Guid AccountRefId { set; get; }

        [ForeignKey("ControlAccount")]
        public Guid ControlAccountRefId { set; get; }

        public String AccountName { set; get; }

        public String AccountNumber { set; get; }

        [ForeignKey("Currency")]
        public Guid? CurrencyRefId { set; get; }

        public virtual Currency Currency { set; get; }

        public ControlAccount ControlAccount { set; get; }

    }
}
