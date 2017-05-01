using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryRefId { set; get; }
        
        public String CategoryName { set; get; }

        public  String CategoryCode { set; get; }

    }
}
