using AccountingPlusDAL.Context;
using AccountingPlusDAL.Models;
using AccountingPlusDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Services
{
    public class StructureService
    {

        private AccountingPlusContext AccountingPlusContext = new AccountingPlusContext();
        private StructureRepository _StructureRepository;


        public StructureRepository StructureRepository
        {
            get
            {
                if (_StructureRepository == null)
                {
                    _StructureRepository = new StructureRepository(AccountingPlusContext);
                }
                return _StructureRepository;
            }
        }


        public List<Structure> GetStructures()
        {
            return this.StructureRepository.GetAll().ToList();
        }

        public Structure GetStructure(Guid StructureRefId)
        {
            return this.StructureRepository.FindById(StructureRefId);
        }

    }
}
