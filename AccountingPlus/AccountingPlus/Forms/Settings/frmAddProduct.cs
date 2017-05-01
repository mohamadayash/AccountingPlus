using AccountingPlusDAL.Models;
using AccountingPlusDAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingPlus.Forms.Settings
{
    public partial class frmAddProduct : Form
    {
        private CurrencyService CurrencyService;
        private ProductService ProductService;

        public frmAddProduct()
        {
            InitializeComponent();
            this.CurrencyService = new CurrencyService();
            this.ProductService = new ProductService();
     
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            this.cboCurrency.DataSource = this.CurrencyService.GetCurrencies();
            this.cboCurrency.DisplayMember = "CurrencyName";
            this.cboCurrency.ValueMember = "CurrencyRefId";


            this.cboUnit.DataSource = this.ProductService.GetUnits();
            this.cboUnit.DisplayMember = "UnitName";
            this.cboUnit.ValueMember = "UnitRefId";

            this.cboCategory.DataSource = this.ProductService.GetCategories();
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryRefId";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.ProductUnit = new ProductUnit();
            this.ProductUnit.ProductRefId = Guid.NewGuid();
            this.ProductUnit.ProductName = this.txtProductName.Text;
            this.ProductUnit.ProductCode = this.txtBarCode.Text;
            this.ProductUnit.CurrencyRefId = (Guid)this.cboCurrency.SelectedValue;
            this.ProductUnit.Price = Decimal.Parse(this.txtPrice.Text);
            this.ProductUnit.UnitRefId = (Guid)cboUnit.SelectedValue;
            this.ProductUnit.CategoryRefId = (Guid?)this.cboCategory.SelectedValue;
            this.ProductUnit.StructureRefId = clsGlobal.CurrentStructure.StructureRefId;
          
         
        }

        public ProductUnit ProductUnit { set; get; }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
