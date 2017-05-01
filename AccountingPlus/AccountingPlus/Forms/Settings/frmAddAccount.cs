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
    public partial class frmAddAccount : Form
    {
        private CurrencyService CurrencyService;
        private Guid ControlAccountRefId;
        public frmAddAccount(Guid ControlAccountRefId)
        {
            InitializeComponent();
            this.CurrencyService = new CurrencyService();
            this.ControlAccountRefId = ControlAccountRefId;
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            this.cboCurrency.DataSource = this.CurrencyService.GetCurrencies();
            this.cboCurrency.DisplayMember = "CurrencyName";
            this.cboCurrency.ValueMember = "CurrencyRefId";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Account = new Account();
            this.Account.AccountRefId = Guid.NewGuid();
            this.Account.AccountName = this.txtAccountName.Text;
            this.Account.CurrencyRefId = (Guid)this.cboCurrency.SelectedValue;
            this.Account.AccountNumber = this.txtAccountCode.Text;
            this.Account.ControlAccountRefId = this.ControlAccountRefId;
          
         
        }

        public Account Account { set; get; }
    }
}
