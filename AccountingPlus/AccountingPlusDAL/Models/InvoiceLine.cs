using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class InvoiceLine
    {
        [Key]
        public Guid InvoiceLineRefId { set; get; }

        [ForeignKey("Invoice")]
        public Guid InvoiceRefId { set; get; }

        [ForeignKey("ProductUnit")]
        public Guid ProductUnitRefId { set; get; }

        public decimal Price { set; get; }

        public decimal Quantity { set; get; }

        [ForeignKey("Currency")]
        public Guid CurrencyRefId { set; get; }

        public decimal InvoiceLineTax { set; get; }

        public decimal InvoiceLineTaxCurr1 { set; get; }

        public decimal InvoiceLineDiscount { set; get; }

        public decimal InvoiceLineDiscountCurr1 { set; get; }

        public decimal InvoiceLineSubTotal { set; get; }

        public decimal InvoiceLineSubTotalCurr1 { set; get; }

        public decimal InvoiceLineTotal { set; get; }

        public decimal InvoiceLineTotalCurr1 { set; get; }

        public virtual Currency Currency { set; get; }

        public virtual Invoice Invoice { set; get; }

        public virtual ProductUnit ProductUnit { set; get; }
    }
}
