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
    public class ProductUnitRepository : GenericRepository<ProductUnit>
    {
        public ProductUnitRepository(AccountingPlusContext context)
            : base(context)
        {

        }
    }
}
