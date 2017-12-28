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
    public partial class MyTextBox : System.Windows.Forms.TextBox, IMyControl
    {
        public MyTextBox()
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

        private void MyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ReadOnly)
                return;
            if (this.Text != this.OldText)
                this.BackColor = Color.FromArgb(173, 216, 230);
            else
                this.BackColor = Color.White;
        }

        private void MyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }

        }

        #region IMyControl 成员


        public void SetText(string value)
        {
            this.Text = value;
        }
        public string GetText()
        {
            return this.Text;
        }
        public void SetInValid()
        {
            this.BackColor = Color.Orange;
        }
        #endregion

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
