using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redsoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add("北京", "Y");
            dt.Rows.Add("上海", "N");
            dt.Rows.Add("南京", "N");
            dt.Rows.Add("哈尔滨", "N");
            myOptions1.Columns = 1;
            myOptions1.BindData(dt);

            ((MyOptionsColumn)dataGridView1.Columns["Column1"]).DataSource = dt;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "哈尔滨";
            dataGridView1.Columns[0].DefaultCellStyle.Format = "";
            dataWindow1.Retrieve("1");
            DataWindow dw = dataWindow1;
            dw.setitem(0, "pihao", "aaaaa");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myOptions1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myOptions1.SetText("哈尔滨");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows[0].Cells[0].FormattedValue.ToString());
            DataWindowTypes dwt = dataWindow1.DataWindowType;

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString() +" "+ e.RowIndex.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }
    }
}
