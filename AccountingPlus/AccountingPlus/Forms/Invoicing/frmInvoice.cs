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

namespace AccountingPlus.Forms.Invoicing
{
    public partial class frmInvoice : Form
    {
        private Invoice InvoiceHeader;
        private List<InvoiceLine> InvoiceLines;
        private BindingSource bsInvoiceLines;
        public frmInvoice()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            InvoiceHeader = new Invoice();
            InvoiceLines = new List<InvoiceLine>();

            bsInvoiceLines = new BindingSource(InvoiceLines, null);

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                InvoiceLine InvoiceLine = (InvoiceLine)bsInvoiceLines.Current;

               

                DataGridViewProductCell DataGridCell = (DataGridViewProductCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                InvoiceLine.ProductUnitRefId = (Guid)DataGridCell.CellValue;

                ProductService pService = new ProductService();

                ProductUnit ProductUnit = pService.GetProductUnit(InvoiceLine.ProductUnitRefId);

                InvoiceLine.Price = ProductUnit.Price;        
            }
            this.dataGridView1.Refresh();
        }

        void bsInvoiceLines_CurrentItemChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bsInvoiceLines;
        }
    }
}
