using System;
using System.Windows.Forms;
using Redsoft;
using System.Data;

public class MyOptionsColumn : DataGridViewColumn
{

    public MyOptionsColumn(DataTable dt)
        : base(new MyOptionsCell(dt))
    {
    }
    public MyOptionsColumn()
        : base(new MyOptionsCell())
    {
    }
    private object _dataSource;

    public object DataSource
    {
        get { return _dataSource; }
        set { _dataSource = value; }
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
                !value.GetType().IsAssignableFrom(typeof(MyOptions)))
            {
                throw new InvalidCastException("±ØÐëÊÇMyOptions¿Ø¼þ");
            }
            base.CellTemplate = value;
        }
    }
}

public class MyOptionsCell : DataGridViewTextBoxCell
{

    public MyOptionsCell(DataTable dt)
        : base()
    {
        // Use the short date format.
      
    }
    
    public MyOptionsCell()
        : base()
    {
    }
    public void SetBold()
    {
        //MyOptionsEditingControl ctl =
        //            DataGridView.EditingControl as MyOptionsEditingControl;
        //if (ctl != null)
        //    ctl.SetBold();
    }
    public void KeyPress(KeyPressEventArgs e)
    {
        //MyOptionsEditingControl ctl =
        //            DataGridView.EditingControl as MyOptionsEditingControl;
        //if (ctl != null)
        //    ctl.txt_KeyPress(null, e);
    }
    public override void InitializeEditingControl(int rowIndex, object
        initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        // Set the value of the editing control to the current cell value.
        base.InitializeEditingControl(rowIndex, initialFormattedValue,
            dataGridViewCellStyle);
        MyOptionsEditingControl ctl =
            DataGridView.EditingControl as MyOptionsEditingControl;
        if (this.Style.Font != null)
        {
            this.Style.Font = new System.Drawing.Font(this.Style.Font, System.Drawing.FontStyle.Regular);
        }
        MyOptionsColumn moc = this.DataGridView.Columns[this.DataGridView.CurrentCell.ColumnIndex] as MyOptionsColumn;
        DataTable dt = (DataTable)moc.DataSource;
        ctl.BindData(dt);
        if (this.Value != null)
        {
            if (ctl.Text != this.Value.ToString())
                ctl.Text = this.Value.ToString();

        }
        else
        {
            ctl.Text = "";
        }
        
    }

    public override Type EditType
    {
        get
        {
            // Return the type of the editing contol that CalendarCell uses.
            return typeof(MyOptionsEditingControl);
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
            return "";
        }
    }
}

class MyOptionsEditingControl : MyOptions, IDataGridViewEditingControl
{
    DataGridView dataGridView;
    private bool valueChanged = false;
    int rowIndex;

    public MyOptionsEditingControl()
    {
        //this.Format = dateFormat;
        this.BorderStyle = BorderStyle.None;
    }

    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
    // property.
    public object EditingControlFormattedValue
    {
        get
        {
            dataGridView.CurrentCell.Tag = this.Tag;
            return this.Text;
        }
        set
        {
            String newValue = value as String;
            if (newValue != null)
            {
                this.Text = newValue;
            }
            else
            {
                this.Text = "";
            }
            dataGridView.CurrentCell.Tag = this.Tag;
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
        this.ForeColor = dataGridViewCellStyle.ForeColor;
        this.BackColor = dataGridViewCellStyle.BackColor;
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
            case Keys.Return:
                return true;
            default:
                return false;
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
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnTextChanged(eventargs);

    }
}

