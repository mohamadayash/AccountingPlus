using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class FiscalYear
    {
        [Key]
        public String EmailRefId { set; get; }

        public String EmailSubject { set; get; }

        public String EmailMailBoxType { set; get; }

        public String EmailBody { set; get; }

        [ForeignKey("FromUser")]
        public String FromUserRefId { set; get; }

        [ForeignKey("ToUser")]
        public String ToUserRefId { set; get; }

        public String Attachment { set; get; }

        public String FileName { set; get; }

        public String EmailTimeStamp { set; get; }

        public String IsReaded { set; get; }

        public String IsGroup { set; get; }

        public virtual User FromUser { set; get; }

        public virtual User ToUser { set; get; }
    }
}
