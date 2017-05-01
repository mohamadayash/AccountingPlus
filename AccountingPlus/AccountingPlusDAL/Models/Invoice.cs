using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceRefId { set; get; }

        public String InvoiceNumber { set; get; }

        public Guid PersonAccountRefId { set; get; }
        
        [ForeignKey("Currency")]
        public Guid CurrencyRefId { set; get; }

        public decimal CurrencyRate {set;get;}

        public DateTime InvoiceDate { set; get; }

        public int InvoiceType { set; get; }

        public String InvoiceReference { set; get; }

        public String InvoiceDescription { set; get; }

        public decimal InvoiceDiscount { set; get; }

        public decimal InvoiceTax { set; get; }

        public decimal InvoiceSubTotal {set;get;}

        public decimal InvoiceTotal {set;get;}

        public virtual Currency Currency { set; get; }
    }
}
