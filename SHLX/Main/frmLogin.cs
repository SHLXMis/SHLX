using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Redsoft
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        void GetSysInfo()
        {
            string appName = "SHLXC#";
            global.g5_sys.app_name = appName;
            string userWin = Environment.UserName;
            global.g5_sys.winusername = "shlx1";//userWin;
            string ip = new nvo_pub_fun().uf_sys_ip_shlx_lan();
            global.g5_sys.ip = ip;
            string mac = Common.GetMACByIP(ip);
            if (mac.Length == 12)
            {
                mac = mac.Insert(4, "-").Insert(9, "-");
            }
            global.g5_sys.mac = mac;
            string hostName = Environment.MachineName;
            global.g5_sys.hostname = hostName;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Common.InitClass(txtUser.Text);
            global.g5_sys.connStr = ConfigurationManager.ConnectionStrings[2].ConnectionString;
#if !DEBUG
            GetSysInfo();
            global.gu_pub1.ue_db();
#endif
            if (txtUser.Text == "")
            {
                MessageBox.Show("请输入用户登录名");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("请输入密码，注意区分大小写！");
                return;
            }
            using (MAction action = new MAction("select user_name1,pass,dbo.MD5('" + txtPassword.Text + "') as inputpass from login_user where user_name1='lhf' ", global.g5_sys.connStr))
            {
                DataTable dt = action.Select().ToDataTable();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("无此账户！");
                    return;
                }
                if (dt.Rows[0]["pass"].ToString() !=
                    dt.Rows[0]["inputpass"].ToString())
                {
                    MessageBox.Show("请输入正确的密码，注意区分大小写！");
                    return;
                }
            }
            this.Hide();
            frmMain main = new frmMain();
            main.Show();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SendKeys.Send("{Tab}");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmdOk_Click(null, null);
        }
    }
}
