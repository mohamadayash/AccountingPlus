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
    public partial class frmVendors : Form
    {

        private PersonService PersonService;
        private AccountService AccountService;

        public frmVendors()
        {
            InitializeComponent();
            this.PersonService = new PersonService();
            this.AccountService = new AccountService();
        }

        private void frmVendors_Load(object sender, EventArgs e)
        {
            this.dgvVendors.AutoGenerateColumns = false;
            this.dgvVendors.DataSource = this.PersonService.GetVendors();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Vendor vendor = new Vendor();
                vendor.VendorRefId = Guid.NewGuid();
                vendor.VendorName = this.txtName.Text;
                vendor.VendorAddress = this.txtAddress.Text;
                vendor.VendorPhone = this.txtPhone.Text;

                Guid? AccountRefId = this.AccountService.CreateAccount(vendor.VendorName, (Guid)clsGlobal.CurrentStructure.VendorAccountsRefId);
                if (AccountRefId != null)
                {
                    vendor.AccountRefId = (Guid)AccountRefId; 
                    if (this.PersonService.InsertVendor(vendor))
                    {

                    }
                    else
                    {
                        throw new Exception("Error in creating the vendor.");
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
