using AccountingPlusDAL.Models;
using AccountingPlusDAL.Repository;
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
    public partial class frmAccounts : Form
    {

        private AccountingPlusDAL.Services.AccountService AccountService;

        private List<ControlAccount> ControlsAccounts;

        List<TempControlAccount> tempcas;

        public frmAccounts()
        {
            InitializeComponent();

            this.tvControlAccount.MouseUp += new System.Windows.Forms.MouseEventHandler(tvControlAccount_MouseUp);
            this.tvControlAccount.AfterSelect += tvControlAccount_AfterSelect;

            AccountService = new AccountingPlusDAL.Services.AccountService();

            this.ControlsAccounts = AccountService.GetControlAccounts();

            this.tempcas = AccountService.GetTempControlAccounts().ToList();
            
            //InsertControlAccounts();

                    
        }

        private void tvControlAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                ControlAccount controlAccount = (ControlAccount)tvControlAccount.SelectedNode.Tag;
                LoadAccounts(controlAccount.ControlAccountRefId);
            }
        }

        private void tvControlAccount_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode node = tvControlAccount.GetNodeAt(p);
                if (node != null)
                {
                    this.ctxControlAccount.Show(tvControlAccount, p);
                }
            }
        }

        private void tvControlAccount_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
      
        }

        private void LoadAccounts(Guid ControlAccountRefId)
        {
            dgvAccounts.DataSource = AccountService.GetAccounts(ControlAccountRefId);

        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            FillControlAccounts();
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AutoGenerateColumns = false;
        }


        private void FillControlAccounts()
        {
            

            List<ControlAccount> toplevelCA = ControlsAccounts.Where(ca => ca.ParentControlAccountRefId.Equals(null)).ToList();

            foreach (ControlAccount ca in toplevelCA)
            {
                TreeNode tnode = new TreeNode(ca.ControlAccountNumber + "- " + ca.ControlAccountName);
                tnode.Tag = ca;
                tvControlAccount.Nodes.Add(tnode);
                FillSubControlAccounts(tnode);
            }
        }

        private void InsertControlAccounts()
        {


            List<TempControlAccount> toplevelCA = this.tempcas.Where(ca => ca.ControlAccountParentRefId.Equals(null)).ToList();

            foreach (TempControlAccount ca in toplevelCA)
            {
                ControlAccount controlAccount = new ControlAccount();
                controlAccount.ControlAccountRefId = Guid.NewGuid();
                controlAccount.ControlAccountName = ca.ControlAccountName;
                controlAccount.ControlAccountNumber = ca.ControlAccountNbr;
                controlAccount.ParentControlAccountRefId = null;
                AccountService.InsertControlAccount(controlAccount);
                InsertSubControlAccounts(ca,controlAccount);
            }
        }

        private void InsertSubControlAccounts(TempControlAccount tempCA,ControlAccount parent)
        {

            List<TempControlAccount> toplevelCA = this.tempcas.Where(ca => ca.ControlAccountParentRefId.Equals(tempCA.ControlAccountRefId)).ToList();
            foreach (TempControlAccount ca in toplevelCA)
            {
                ControlAccount controlAccount = new ControlAccount();
                controlAccount.ControlAccountRefId = Guid.NewGuid();
                controlAccount.ControlAccountName = ca.ControlAccountName;
                controlAccount.ControlAccountNumber = ca.ControlAccountNbr;
                controlAccount.ParentControlAccountRefId = parent.ControlAccountRefId;
                AccountService.InsertControlAccount(controlAccount);
                InsertSubControlAccounts(ca,controlAccount);
            }
        }


        private void FillSubControlAccounts(TreeNode parentNode)
        {
            ControlAccount controlAccount = (ControlAccount)parentNode.Tag;
            List<ControlAccount> toplevelCA = ControlsAccounts.Where(ca => ca.ParentControlAccountRefId.Equals(controlAccount.ControlAccountRefId)).ToList();
            foreach (ControlAccount ca in toplevelCA){
                TreeNode tnode = new TreeNode(ca.ControlAccountNumber +"- " +ca.ControlAccountName);
                tnode.Tag = ca;
                parentNode.Nodes.Add(tnode);
                FillSubControlAccounts(tnode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlAccount controlAccount = (ControlAccount)tvControlAccount.SelectedNode.Tag;
            frmAddAccount frmAddAccount = new frmAddAccount(controlAccount.ControlAccountRefId);
            if (frmAddAccount.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AccountService.CreateAccount(frmAddAccount.Account);
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAccount controlAccount = (ControlAccount)tvControlAccount.SelectedNode.Tag;
            frmAddControlAccount frmAddControlAccount = new frmAddControlAccount(controlAccount.ParentControlAccountRefId);
            if (frmAddControlAccount.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AccountService.InsertControlAccount(frmAddControlAccount.ControlAccount);
                this.AddNodeToUI(tvControlAccount.SelectedNode.Parent, frmAddControlAccount.ControlAccount);
            }
        }

        private void newChildAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAccount controlAccount = (ControlAccount)tvControlAccount.SelectedNode.Tag;
            frmAddControlAccount frmAddControlAccount = new frmAddControlAccount(controlAccount.ControlAccountRefId);
            if (frmAddControlAccount.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AccountService.InsertControlAccount(frmAddControlAccount.ControlAccount);
                this.AddNodeToUI(tvControlAccount.SelectedNode, frmAddControlAccount.ControlAccount);
            }
        }

        private void AddAccountToInterface(TreeNode node, ControlAccount controlAccount)
        {
            TreeNode treeNode = new TreeNode(controlAccount.ControlAccountName);
            treeNode.Tag = controlAccount;
            if (node == null)
            {
                tvControlAccount.Nodes.Add(treeNode);
            }
            else
            {
                node.Nodes.Add(treeNode);
            }

        }


        private void AddNodeToUI(TreeNode node,ControlAccount controlAccount)
        {
            TreeNode treeNode = new TreeNode(controlAccount.ControlAccountName);
            treeNode.Tag = controlAccount;
            if (node == null)
            {
                tvControlAccount.Nodes.Add(treeNode);
            }
            else
            {
                node.Nodes.Add(treeNode);
            }
            
        }

        private void RemoveNodeFromUI(TreeNode node)
        {
            if (node.Parent == null)
            {
                tvControlAccount.Nodes.Remove(node);
            }
            else
            {
                node.Parent.Nodes.Remove(node);
            }
       
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAccount controlAccount = (ControlAccount)tvControlAccount.SelectedNode.Tag;
            AccountService.DeleteControlAccount(controlAccount.ControlAccountRefId);
            RemoveNodeFromUI(tvControlAccount.SelectedNode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }


    }
}
