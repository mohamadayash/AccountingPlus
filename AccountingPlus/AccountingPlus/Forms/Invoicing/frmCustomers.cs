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
    public partial class frmCustomers
 : Form
    {

        private PersonService PersonService;
        private AccountService AccountService;

        public frmCustomers()
        {
            InitializeComponent();
            this.PersonService = new PersonService();
            this.AccountService = new AccountService();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            this.dgvCustomers.AutoGenerateColumns = false;
            this.dgvCustomers.DataSource = this.PersonService.GetCustomers();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.CustomerRefId = Guid.NewGuid();
                customer.CustomerName = this.txtName.Text;
                customer.CustomerAddress = this.txtAddress.Text;
                customer.CustomerPhone = this.txtPhone.Text;

                Guid? AccountRefId = this.AccountService.CreateAccount(customer.CustomerName, (Guid)clsGlobal.CurrentStructure.CustomerAccountsRefId);
                if (AccountRefId != null)
                {
                    customer.AccountRefId = (Guid)AccountRefId;
                    if (this.PersonService.InsertCustomer(customer))
                    {

                    }
                    else
                    {
                        throw new Exception("Error in creating the customer");
                    }
                }
                else
                {
                    throw new Exception("Error in generating account number.");
                }
            }
            catch (Exception ex)
            {

            }
                    
        }
    }
}
