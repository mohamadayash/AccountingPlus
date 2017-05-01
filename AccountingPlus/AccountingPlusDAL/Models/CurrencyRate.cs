using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class CurrencyRate
    {
        public Guid CurrencyRateRefId { set; get; }

        public Guid CurrencyRefId { set; get; }

        public DateTime Date { set; get; }
    }
}
