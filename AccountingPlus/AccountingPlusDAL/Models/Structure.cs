using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Structure
    {
        [Key]
        public Guid StructureRefId { set; get; }

        public String StructureCode { set; get; }

        public String StructureName { set; get; }
        [ForeignKey("SalesAccount")]
        public Guid? SalesAccountRefId { set; get; }

        [ForeignKey("PurchaseAccount")]
        public Guid? PurchaseAccountRefId { set; get; }

        [ForeignKey("CustomerAccounts")]
        public Guid? CustomerAccountsRefId { set; get; }

        [ForeignKey("VendorAccounts")]
        public Guid? VendorAccountsRefId { set; get; }


        public Account SalesAccount { set; get; }

        public Account PurchaseAccount { set; get; }

        public ControlAccount CustomerAccounts { set; get; }

        public ControlAccount VendorAccounts { set; get; }

    }
}
