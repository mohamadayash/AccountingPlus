using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Services
{
    public class ServiceManager
    {


        public static AccountService AccountService
        {
            get
            {
                return new AccountService();
            }
        }


    }
}
