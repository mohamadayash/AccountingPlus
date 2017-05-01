using AccountingPlusDAL.Models;
using AccountingPlusDAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlus
{
    public class clsGlobal
    {

        private static Structure currentStructure;
        public static Structure CurrentStructure
        {
            get
            {
                if (currentStructure == null)
                    currentStructure = new StructureService().GetStructure(Guid.Parse("0fb85380-b764-4a5e-be6c-3d7957b881c1"));
                return currentStructure;
            }
        }

        public static Guid CurrentFiscalYear { set; get; }

        



    }
}
