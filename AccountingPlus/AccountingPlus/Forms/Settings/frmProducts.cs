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
    public partial class frmProducts : Form
    {

        ProductService ProductService = new ProductService();
        public frmProducts()
        {
            InitializeComponent();

            dataGridView1.CellMouseDoubleClick+=dataGridView1_CellMouseDoubleClick;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0){
                this.ProductUnit = (ProductUnit)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } 
        }

        public ProductUnit ProductUnit { set; get; }

        public List<ProductUnit> Products;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddProduct frmAddProduct = new frmAddProduct();
            if (frmAddProduct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProductService.InsertProductUnit(frmAddProduct.ProductUnit);
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            Products = this.ProductService.GetProductUnits();
            dataGridView1.DataSource = Products;
        }
    }
}
