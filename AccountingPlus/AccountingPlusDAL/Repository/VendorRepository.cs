using AccountingPlusDAL.Context;
using AccountingPlusDAL.Models;
using ServerMonitorDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Repository
{
    public class VendorRepository : GenericRepository<Vendor>
    {
        public VendorRepository(AccountingPlusContext context):base (context)
        {

        }
    }
}
