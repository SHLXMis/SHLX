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
    public partial class MyDateTime : MaskedTextBox  ,IMyControl 
    {
        public MyDateTime()
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

        private void MyDate_TextChanged(object sender, EventArgs e)
        {
            if (this.ReadOnly)
                return;
            if (this.OldText.Length>=this.Mask.Length && this.Text != this.OldText.Substring(0, this.Mask.Length))
                this.BackColor = Color.FromArgb(173, 216, 230);
            else
                this.BackColor = Color.White;
            
        }

        private void MyDate_Validated(object sender, EventArgs e)
        {
            
            if (this.Text != "" && this.Text.Replace(" ","").Replace("-","").Replace(":","")!="")
            {
                DateTime dt;
                if (!DateTime.TryParse(this.Text, out dt))
                    this.BackColor = Color.Orange;
            }
        }

        private void MyDate_KeyUp(object sender, KeyEventArgs e)
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
            if (this.Text.Replace(" ", "").Replace("-", "").Replace(":", "") == "")
                return "";
            else
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
