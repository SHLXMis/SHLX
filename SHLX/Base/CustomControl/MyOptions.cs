using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redsoft
{
    public partial class MyOptions : UserControl, IMyControl
    {
        public MyOptions()
        {
            InitializeComponent();
        }
        private string oldText = "";
        [Description("数据库原值"), Category("自定义属性")]
        // 控件的自定义属性值 
        public string OldText
        {
            get
            {
                return oldText;
            }
            set
            {
                oldText = value;
            }
        }
        public override string Text
        {
            get
            {
                foreach (Control c in this.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                        return rb.Text;
                }
                    return "";
            }
            set
            {
                foreach (Control c in this.Controls)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Text == value)
                    {
                        rb.Checked = true;
                        return;
                    }
                }
            }
        }
        private int columns;
        [Description("Columns"), Category("自定义属性")]
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
                
            }
        }

        private void MyOptions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }
        
        public string GetText()
        {
            foreach (Control c in this.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Checked)
                    return rb.Text;
            }
            return "";
        }
        #region IMyControl 成员


        public void SetText(string value)
        {
            foreach (Control c in this.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb.Text == value)
                {
                    rb.Checked = true;
                    return;
                }
            }
           
        }
        public void SetInValid()
        {
            this.BackColor = Color.Orange;
        }
        #endregion
        public void BindData(DataTable dt)
        {
            this.Controls.Clear();
            if (this.columns == 0)
                this.columns = dt.Rows.Count;
            int width = this.Width / this.columns;
            int top = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                top = (int)Math.Floor((double)(i / columns));
                RadioButton rb = new RadioButton();
                rb.Left = width * (i % columns);
                rb.Top = top * 20;
                rb.Text = dt.Rows[i][0].ToString();
                rb.Width = width;
                rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
                rb.KeyUp += new KeyEventHandler(rb_KeyUp);
                this.Controls.Add(rb);
            }
        }

        void rb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }

        void rb_CheckedChanged(object sender, EventArgs e)
        {
            GetText();
            if (this.Text != this.OldText)
                this.BackColor = Color.FromArgb(173, 216, 230);
            else
                this.BackColor = Color.White;
            OnTextChanged(e);
        }
        public event EventHandler TextChange;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (TextChange != null)
            {
                TextChange(this, e);
            }
        }
        private string allowUpdate;
        public string AllowUpdate
        {
            get
            {
                return allowUpdate;
            }
            set
            {
                allowUpdate = value;
            }
        }
    }
}
