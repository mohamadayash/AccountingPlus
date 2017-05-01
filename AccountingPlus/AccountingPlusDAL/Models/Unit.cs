using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Unit
    {

        [Key]
        public Guid UnitRefId { set; get; }

        public string UnitName { set; get; }

        public String UnitCode { set; get; }
    }
}
