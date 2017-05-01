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
    public partial class frmAddControlAccount : Form
    {
        private CurrencyService CurrencyService;
        private Guid? ControlAccountRefId;
        public frmAddControlAccount(Guid? controlAccountRefId)
        {
            InitializeComponent();
            this.CurrencyService = new CurrencyService();
            this.ControlAccountRefId = controlAccountRefId;
        }

        private void frmAddControlAccount_Load(object sender, EventArgs e)
        {
            this.cboCurrency.DataSource = this.CurrencyService.GetCurrencies();
            this.cboCurrency.DisplayMember = "CurrencyName";
            this.cboCurrency.ValueMember = "CurrencyRefId";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.ControlAccount = new ControlAccount();
            this.ControlAccount.ControlAccountRefId = Guid.NewGuid();
            this.ControlAccount.ControlAccountName = this.txtControlAccountName.Text;
            this.ControlAccount.ControlAccountNumber = this.txtControlAccountCode.Text;
            this.ControlAccount.ParentControlAccountRefId = ControlAccountRefId;
        }

        public ControlAccount ControlAccount { set; get; }
    }
}
