namespace AccountingPlus.Forms.Settings
{
    partial class frmCurrency
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvCurrency = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.chkIsBaseCurrency = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.CurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBaseCurrency = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 510);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 510);
            this.panel2.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvCurrency);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(539, 325);
            this.panel7.TabIndex = 7;
            // 
            // dgvCurrency
            // 
            this.dgvCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurrencyName,
            this.CurrencySymbol,
            this.Operator,
            this.Rate,
            this.IsBaseCurrency});
            this.dgvCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrency.Location = new System.Drawing.Point(0, 0);
            this.dgvCurrency.Name = "dgvCurrency";
            this.dgvCurrency.Size = new System.Drawing.Size(539, 325);
            this.dgvCurrency.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.cboOperator);
            this.panel6.Controls.Add(this.chkIsBaseCurrency);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.btnAdd);
            this.panel6.Controls.Add(this.txtRate);
            this.panel6.Controls.Add(this.txtName);
            this.panel6.Controls.Add(this.txtSymbol);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 325);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(539, 185);
            this.panel6.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Operator";
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "*",
            "/"});
            this.cboOperator.Location = new System.Drawing.Point(70, 61);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(260, 21);
            this.cboOperator.TabIndex = 9;
            // 
            // chkIsBaseCurrency
            // 
            this.chkIsBaseCurrency.AutoSize = true;
            this.chkIsBaseCurrency.Location = new System.Drawing.Point(70, 120);
            this.chkIsBaseCurrency.Name = "chkIsBaseCurrency";
            this.chkIsBaseCurrency.Size = new System.Drawing.Size(108, 17);
            this.chkIsBaseCurrency.TabIndex = 8;
            this.chkIsBaseCurrency.Text = "Is Base Currency";
            this.chkIsBaseCurrency.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Symbol";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(70, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(70, 87);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(260, 20);
            this.txtRate.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(70, 36);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(260, 20);
            this.txtSymbol.TabIndex = 3;
            // 
            // CurrencyName
            // 
            this.CurrencyName.DataPropertyName = "CurrencyName";
            this.CurrencyName.HeaderText = "Currency Name";
            this.CurrencyName.Name = "CurrencyName";
            // 
            // CurrencySymbol
            // 
            this.CurrencySymbol.DataPropertyName = "CurrencySymbol";
            this.CurrencySymbol.HeaderText = "Symbol";
            this.CurrencySymbol.Name = "CurrencySymbol";
            // 
            // Operator
            // 
            this.Operator.DataPropertyName = "CurrencyOperator";
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "CurrencyRate";
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // IsBaseCurrency
            // 
            this.IsBaseCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsBaseCurrency.DataPropertyName = "IsBaseCurrency";
            this.IsBaseCurrency.HeaderText = "Is Base Currency";
            this.IsBaseCurrency.Name = "IsBaseCurrency";
            this.IsBaseCurrency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsBaseCurrency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 510);
            this.Controls.Add(this.panel1);
            this.Name = "frmCurrency";
            this.Text = "Currency";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvCurrency;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkIsBaseCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsBaseCurrency;
    }
}