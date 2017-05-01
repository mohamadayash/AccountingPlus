using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Models
{
    public class ProductUnit
    {
        [Key]
        public Guid ProductRefId { set; get; }
     
        public String ProductName { set; get; }

        public String ProductCode { set; get; }

        [ForeignKey("Structure")]
        public Guid? StructureRefId { set; get; }

        [ForeignKey("Category")]
        public Guid? CategoryRefId { set; get; }

        [ForeignKey("Unit")]
        public Guid UnitRefId { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("Currency")]
        public Guid CurrencyRefId { set; get; }

        public Guid? ProductSalesAccountRefId { set; get; }

        public Guid? ProductPurchaseAccountRefId { set; get; }

        public virtual Unit Unit { set; get; }

        public virtual Currency Currency { set; get; }

        public virtual Category Category { set; get; }

        public virtual Structure Structure { set; get; }

        public String UnitName
        {
            get
            {
                return this.Unit.UnitName;
            }
        }

        public String CurrencyCode
        {
            get
            {
                return this.Currency.CurrencySymbol;
            }
        }

        public String CategoryName
        {
            get
            {
                return this.Category.CategoryName;
            }
        }

    }
}
