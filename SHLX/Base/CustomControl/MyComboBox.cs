using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;

namespace Redsoft
{
    public partial class MyComboBox : ComboBox,IMyControl
    {
        public MyComboBox()
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
        private DataTable listData ;
        [Description("data"), Category("自定义属性")]
        // 控件的自定义属性值 
        public DataTable ListData
        {
            get
            {
                return listData;
            }
            set
            {

                listData = value;
            }
        }
       

        private void MyComboBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Text != this.OldText)
                this.BackColor = Color.FromArgb(173, 216, 230);
            else
                this.BackColor = Color.White;
        }

        private void MyComboBox_TextUpdate(object sender, EventArgs e)
        {
            string initText = this.Text;
            
            if (listData == null)
                return;
            DataTable newlist = new DataTable();
            foreach (DataColumn dc in listData.Columns)
            {
                newlist.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow r in listData.Rows)
            {
                if (r[0].ToString().Contains(this.Text))
                {
                    DataRow newr = newlist.Rows.Add();
                    foreach (DataColumn dc in listData.Columns)
                    {
                        newr[dc.ColumnName] = r[dc.ColumnName];
                    }
                }
            }
            this.DataSource = newlist;
            this.Text = initText;
            this.SelectionStart = this.Text.Length;
            this.DroppedDown = true;
        }

        private void MyComboBox_Enter(object sender, EventArgs e)
        {
            this.DroppedDown = true;

        }

        private void MyComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void MyComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{Tab}");
            }
        }



        #region IMyControl 成员


        public void SetText(string value)
        {
            if (this.Items.Count > 0)
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

        private void MyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Text != this.OldText)
                this.BackColor = Color.FromArgb(173, 216, 230);
            else
                this.BackColor = Color.White;
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
