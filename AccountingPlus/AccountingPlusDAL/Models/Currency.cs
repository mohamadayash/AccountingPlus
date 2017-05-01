using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Currency
    {
        [Key]
        public Guid CurrencyRefId { set; get; }

        public String CurrencyName { set; get; }

        public String CurrencySymbol { set; get; }

        public decimal CurrencyRate { set; get; }

        public String CurrencyOperator { set; get; }

        public Boolean IsBaseCurrency { set; get; }

        public Guid StructureRefId { set; get; }

    }
}
