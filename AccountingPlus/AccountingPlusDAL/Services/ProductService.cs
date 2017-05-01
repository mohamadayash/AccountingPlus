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
    public class ProductService
    {
        private AccountingPlusContext AccountingPlusContext = new AccountingPlusContext();
        private ProductUnitRepository _ProductUnitRepository;



        public ProductUnitRepository ProductUnitRepository
        {
            get
            {
                if (_ProductUnitRepository == null)
                {
                    _ProductUnitRepository = new ProductUnitRepository(AccountingPlusContext);
                }
                return _ProductUnitRepository;
            }
        }



        private UnitRepository _UnitRepository;



        public UnitRepository UnitRepository
        {
            get
            {
                if (_UnitRepository == null)
                {
                    _UnitRepository = new UnitRepository(AccountingPlusContext);
                }
                return _UnitRepository;
            }
        }


        private CategoryRepository _CategoryRepository;



        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new CategoryRepository(AccountingPlusContext);
                }
                return _CategoryRepository;
            }
        }

        public ProductUnit GetProductUnit(Guid ProductUnitRefId)
        {
            return this.ProductUnitRepository.FindById(ProductUnitRefId);
        }


        public List<ProductUnit> GetProductUnits()
        {
            return this.ProductUnitRepository.GetAll().ToList();
        }

        public Boolean InsertProductUnit(ProductUnit productUnit)
        {
            try
            {
                this.ProductUnitRepository.Add(productUnit);
                return this.ProductUnitRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Unit> GetUnits()
        {
            return this.UnitRepository.GetAll().ToList();
        }

        public Boolean InsertUnit(Unit Unit)
        {
            try
            {
                this.UnitRepository.Add(Unit);
                return this.ProductUnitRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Category> GetCategories()
        {
            return this.CategoryRepository.GetAll().ToList();
        }

        public Boolean InsertCategory(Category Category)
        {
            try
            {
                this.CategoryRepository.Add(Category);
                return this.ProductUnitRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
