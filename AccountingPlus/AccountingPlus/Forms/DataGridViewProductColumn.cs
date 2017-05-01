using AccountingPlus.Forms.Settings;
using AccountingPlusDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Forms;


namespace AccountingPlus
{
    public class DataGridViewProductColumn : DataGridViewColumn
    {
        public DataGridViewProductColumn()
            : base(new DataGridViewProductCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewProductCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }

        [Category("My Properties")]
        [Description("MyToolWindowControl properties")]
        public String TTTLLL { set; get; }
    }

    public class DataGridViewProductCell : DataGridViewTextBoxCell
    {

        private String DisplayValue = null;

        public Guid CellValue { set; get; }

        public DataGridViewProductCell()
            : base()
        {
            // Use the short date format.
            //this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataGridViewProductEditingControl ctl =
                DataGridView.EditingControl as DataGridViewProductEditingControl;

            ctl.OwnerCell = this;

        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(DataGridViewProductEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(String);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DBNull.Value ;
            }
        }


        public void SetDisplayValue(String value){
            this.DisplayValue = value;
        }




        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (DisplayValue == null)
            {
                SetDisplayValue(DisplayValue);
            }
            
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, DisplayValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

    
    }

    class DataGridViewProductEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;


        private Button btnDialog;
        private ProductUnit ProductUnit;

        private static frmProducts frmProducts;

        public DataGridViewProductEditingControl()
        {

            btnDialog = new Button();
            btnDialog.Size = new System.Drawing.Size(25, this.ClientSize.Height + 20);
            btnDialog.Dock = DockStyle.Right;
            btnDialog.Margin = new Padding(0);
            btnDialog.Cursor = Cursors.Default;
            //btn.Image = Properties.Resources.star;
            this.Controls.Add(btnDialog);

            btnDialog.Click += btnDialog_click;
        }

        private DataGridViewProductCell currentCell;

        public DataGridViewProductCell OwnerCell { 
            set {
                currentCell = value;
                
            } 
            get {
                return currentCell;
            } 
        }

        private void btnDialog_click(object sender, EventArgs e)
        {
            if (frmProducts == null)
            {
                frmProducts = new frmProducts();
            }
            
            if (frmProducts.ShowDialog() == DialogResult.OK)
            {
                this.ProductUnit = frmProducts.ProductUnit;
                this.Text = frmProducts.ProductUnit.ProductName;
                OwnerCell.CellValue = frmProducts.ProductUnit.ProductRefId;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {

                return this.Text;

            }
            set
            {
                if (value is String)
                {
                    this.Text = (String)value;
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnTextChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            if (ProductUnit != null)
            {
                OwnerCell.CellValue = ProductUnit.ProductRefId;
                OwnerCell.SetDisplayValue(ProductUnit.ProductName);
                
            }
     
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(eventargs);
        }
    }
}
