using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class ControlAccount
    {
        [Key]
        public Guid ControlAccountRefId { set; get; }

        [ForeignKey("ParentControlAccount")]
        public Guid? ParentControlAccountRefId { set; get; }

        public String ControlAccountName { set; get; }

        public String ControlAccountNumber { set; get; }

        public int Length { set; get; }
        
        [ForeignKey("Structure")]
        public Guid? StructureRefId { set; get; }

        public ControlAccount ParentControlAccount { set; get; } 

        public virtual Structure Structure { set; get; }

    }
}
