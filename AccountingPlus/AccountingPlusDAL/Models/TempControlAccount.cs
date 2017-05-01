using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class TempControlAccount
    {
        [Key]
        public int ControlAccountRefId { set; get; }
        public string ControlAccountName { set; get; }
        public string ControlAccountNbr { set; get; }
        public int? ControlAccountCounter { set; get; }
        public int? ControlAccountParentRefId { set; get; }
        public string ControlAccountTypeRefId { set; get; }
        public string ControlAccountTreeRefIds { set; get; }
        public int? AccountLength { set; get; }
        public Boolean? AllowTransaction { set; get; }
        public int? StructureRefId { set; get; }
        public int? OrganizationRefId { set; get; }
        public Boolean? InActive { set; get; }
        public string CUser { set; get; }
        public string MUser { set; get; }
        public string CDate { set; get; }
        public string MDate { set; get; }
        public Guid? RowGUID { set; get; }
        public Boolean? ObligatoryStructureCC { set; get; }
        public Boolean? ObligatoryJobCC { set; get; }
    }
}
