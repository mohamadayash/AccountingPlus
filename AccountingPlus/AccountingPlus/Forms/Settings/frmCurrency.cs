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
    public partial class frmCurrency : Form
    {

        private CurrencyService CurrencyService;
        public frmCurrency()
        {
            InitializeComponent();
            dgvCurrency.AutoGenerateColumns = false;
            this.CurrencyService = new CurrencyService();
            this.dgvCurrency.DataSource = CurrencyService.GetCurrencies();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Currency currency = new Currency();
            currency.CurrencyRefId = Guid.NewGuid();
            currency.CurrencyName = this.txtName.Text;
            currency.CurrencySymbol = this.txtSymbol.Text;
            currency.CurrencyRate = Decimal.Parse(this.txtRate.Text);
            currency.CurrencyOperator = (String)cboOperator.SelectedValue;
            currency.IsBaseCurrency = this.chkIsBaseCurrency.Checked;
            currency.StructureRefId = clsGlobal.CurrentStructure.StructureRefId;

            if (this.CurrencyService.InsertCurrency(currency))
            {
                MessageBox.Show("Currency successfully created.");
            }
        }

    }
}
