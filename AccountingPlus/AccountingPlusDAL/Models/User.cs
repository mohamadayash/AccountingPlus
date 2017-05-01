using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class User
    {
        [Key]
        public String UserRefId { set; get; }

        public String UserId { set; get; }

        public String UserName { set; get; }

        public String UserPassword { set; get; }

        public Boolean IsActive { set; get; }

        public int UserType { set; get; }

        public String ACLToken { set; get; }

        public String PasswordLastChange { set; get; }

        public String NumberOfMessages { set; get; }

        public String NumberOfEmails { set; get; }

        public String PublicKeyX { set; get; }

        public String PublicKeyY { set; get; }


    }
}
