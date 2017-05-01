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
    public class StructureRepository : GenericRepository<Structure>
    {
        public StructureRepository(AccountingPlusContext context)
            : base(context)
        {

        }
    }
}
