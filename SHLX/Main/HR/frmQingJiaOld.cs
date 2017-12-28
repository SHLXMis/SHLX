using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sybase.DataWindow;

namespace SHLX.HR
{
    public partial class frmQingJiaOld : Form
    {
        public frmQingJiaOld()
        {
            InitializeComponent();
        }
        SqlConnection dbConn;
        AdoTransaction adoTrans;
        private void frmQingJia_Load(object sender, EventArgs e)
        {
            //连接数据库，并检索数据
            dbConn = new SqlConnection("Server=redt430\\sql2008; DataBase=shlx;uid=sa;pwd=janet");
            dbConn.Open();
            try
            {
                adoTrans = new AdoTransaction(dbConn);
                adoTrans.BindConnection();
                dataWindowControl1.SetTransaction(adoTrans);

                dataWindowControl1.Retrieve();

               
            }
            catch
            { 
            }
        }

        private void dataWindowControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataWindowControl1_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                dataWindowControl2.SetTransaction(adoTrans);
                dataWindowControl2.Retrieve(dataWindowControl1.CurrentRow);
                
            }
        }

        private void dataWindowControl1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            dataWindowControl2.SetTransaction(adoTrans);
            dataWindowControl2.Retrieve(dataWindowControl1.CurrentRow);
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
