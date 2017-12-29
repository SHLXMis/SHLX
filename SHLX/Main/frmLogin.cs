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
#if DEBUG
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
            //using (MAction action = new MAction("select user_name1,pass,dbo.MD5('" + txtPassword.Text + "') as inputpass from login_user where user_name1='shlx1' ", global.g5_sys.connStr))
            ////using (MAction action = new MAction("select user_name1,pass,dbo.MD5('" + txtPassword.Text + "') as inputpass from login_user where user_name1='lhf' ", global.g5_sys.connStr))
            //{
            //    DataTable dt = action.Select().ToDataTable();
            //    if (dt.Rows.Count == 0)
            //    {
            //        MessageBox.Show("无此账户！");
            //        return;
            //    }
            //    if (dt.Rows[0]["pass"].ToString() !=
            //        dt.Rows[0]["inputpass"].ToString())
            //    {
            //        MessageBox.Show("请输入正确的密码，注意区分大小写！");
            //        return;
            //    }
            //}
            Login();
        }

        private void Login()
        {

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("请输入用户名！", "提示");
                txtUser.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入密码！", "提示");
                txtPassword.Focus();
                return;
            }
            if (txtUser.Text.Contains(" "))
            {
                MessageBox.Show("用户名中输入的有空格！", "提示");
                txtUser.Focus();
                return;
            }
            if (txtPassword.Text.Contains(" "))
            {
                MessageBox.Show("密码中输入的有空格！", "提示");
                txtPassword.Focus();
                return;
            }

            if (global.gu_dw1.f_sql_filter(txtUser.Text) == 0)
            {
                MessageBox.Show("用户名中输入的有不合法的字符！", "提示");
                txtUser.Focus();
                return;
            }
            if (global.gu_dw1.f_sql_filter(txtPassword.Text) == 0)
            {
                MessageBox.Show("密码中输入的有不合法的字符！", "提示");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text == "88888888")
            {
                MessageBox.Show("请修改密码，88888888 不能登录！", "提示");
                txtPassword.Focus();
                return;
            }

            // 初始化变量
            string[] ls_sle;
            string ls_password, ls_logid;
            ls_logid = "";
            ls_password = "";
            ls_logid = txtUser.Text.ToLower();
            ls_password = txtPassword.Text;

            //----------------------------------修改此段程序-----------------//
            string ls_return = string.Empty, ls_truename, ls_msg = string.Empty, ls_ip_hostname;
            long ll_pass_ts = 0, ll_i = 0;
            long ll_bmcj_count;
            long return_value = 0;
            bool lb_sql;
            lb_sql = false;

            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = new SqlParameter("@ls_return", SqlDbType.VarChar, 2000);
            para.Direction = ParameterDirection.Output;
            outparas.Add(para);
            para = new SqlParameter("@return_value", SqlDbType.Int);
            para.Direction = ParameterDirection.ReturnValue;
            outparas.Add(para);
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@leibie", 52);
            paras.Add(para);
            para = new SqlParameter("@user_name1", ls_logid);
            paras.Add(para);
            para = new SqlParameter("@page_name", "");
            paras.Add(para);
            para = new SqlParameter("@pass", ls_password);
            paras.Add(para);
            para = new SqlParameter("@pass_new", "shlx9");
            paras.Add(para);
            para = new SqlParameter("@ip", global.g5_sys.ip);
            paras.Add(para);
            try
            {
                Dictionary<string, string> dict = DBAccess.ExecSP("login_gnqx_pass", paras, ref outparas);
                ls_return = dict["@ls_return"];
                return_value = Convert.ToInt64(dict["@return_value"]);
                lb_sql = true;
            }
            catch (Exception e)
            {
                lb_sql = false;
            }
            if (!lb_sql)
            {
                global.g5_sys.username = "";
                global.g5_sys.truename = "";
                global.g5_shlx.chengben = false;
                MessageBox.Show("返回值：" + return_value, "提示!");
                return;
            }

            switch (ls_return)
            {
                case "pass_time_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //global.w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，同一IP地址在1分钟内不能登录两次！", "登录不成功提示1!");
                    return;
                case "pass_date_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，您的密码已过期，请修改密码！", "登录不成功提示2!");
                    return;
                case "pass_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，密码或用户名有误，密码区分大小写！", "登录不成功提示3!");
                    return;
                case "leixing_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，计算机类型不正确，请把类型更改为“台式机”或“笔记本”！", "登录不成功提示4!");
                    return;
                case "admi_user_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，管理员设置不正确或计算机异常，请联系信息部！", "登录不成功提示5!");
                    return;
                case "wan_false":
                    global.g5_sys.username = "";
                    global.g5_sys.truename = "";
                    global.g5_shlx.chengben = false;
                    //w_pub_init.st_truename.text="使用者："
                    MessageBox.Show("登录不成功，您没有开通外网访问权限，请联系信息部！", "登录不成功提示6!");
                    return;
                default:
                    if (ls_return.Substring(0, 2) == "p_" || ls_return.Substring(0, 2) == "p!")
                    {
                        global.g5_sys.username = ls_logid;
                        global.gu_dw1.wf_str_sys_dws2(global.g5_sys.username);
                        if (ls_return.Substring(0, 2) == "p_")
                        {
                            ls_truename = ls_return.Substring(ls_return.Length - 2, 2);
                            ll_pass_ts = Convert.ToInt64(ls_truename.Substring(0, ls_truename.IndexOf("!")));
                            global.g5_sys.truename = ls_truename.Substring(ls_truename.IndexOf("!") + 1);
                        }
                        else
                        {
                            global.g5_sys.truename = ls_return.Substring(ls_return.Length - 2, 2);
                        }
                        if (global.g5_sys.truename == "管理员")
                            global.g5_sys.truename = "李华锋";
                        string sql = @"
			select bumen, chejian from login_user where user_name1 = :g5_sys.username ;";
                        DataSet ds = DBAccess.Query(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            global.g5_sys.bumen = Convert.ToString(dr[0]);
                            global.g5_sys.chejian = Convert.ToString(dr[1]);
                        }
                        //w_pub_init.st_truename.text="使用者："+g5_sys.truename+" "+g5_sys.username
                        //w_pub_init.st_chejian.text="车间：" + g5_sys.bumen + " " + g5_sys.chejian
                        if (global.g5_sys.bumen != global.g5_shlx.com_bumen || global.g5_sys.chejian != global.g5_shlx.com_chejian)
                        {
                            sql = string.Format(@"
				insert into com_user_bmcj (computer,ip,mac,bumen_com,chejian_com,
						user_name1,true_name,bumen,chejian,login_sj)
				values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',getdate()) ;", global.g5_sys.hostname,
                                                                                                                 global.g5_sys.ip,
                                                                                                                 global.g5_sys.mac,
                                                                                                                 global.g5_shlx.com_bumen,
                                                                                                                 global.g5_shlx.com_chejian,
                                                                                                                 global.g5_sys.username,
                                                                                                                 global.g5_sys.truename,
                                                                                                                 global.g5_sys.bumen,
                                                                                                                 global.g5_sys.chejian);
                            DBAccess.ExecuteSql(sql);

                            ; if (global.g5_shlx.com_bumen == "会议室" && global.g5_shlx.com_chejian == "会议室")
                                ll_bmcj_count = 0;
                            else if (global.g5_sys.hostname == "三环乐喜1" || global.g5_sys.hostname == "三环乐喜2")
                                ll_bmcj_count = 0;
                            else
                            {
                                ll_bmcj_count = 0;
                                sql = @"
					select count(com_user_id) from com_user_bmcj
						where login_sj >= getdate() - 30 and ip = :g5_sys.ip and user_name1 = :g5_sys.username ;";
                                ds = DBAccess.Query(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    DataRow dr = ds.Tables[0].Rows[0];
                                    ll_bmcj_count = Convert.ToInt64(dr[0]);
                                }
                                ls_msg = "计算机 " + global.g5_sys.hostname + " 所在部门车间为 " + global.g5_shlx.com_bumen + "/" + global.g5_shlx.com_chejian;
                                ls_msg += "\r\n用户 " + global.g5_sys.truename + "/" + global.g5_sys.username + " 所在部门车间为 " + global.g5_sys.bumen + "/" + global.g5_sys.chejian;
                                if (ll_bmcj_count >= 30)
                                {
                                    ls_msg += "\r\n两者不一致，您将不能使用shlx9，请找您们领导在shlx9中报修！";
                                    MessageBox.Show(ls_msg, "部门车间不一致提示");
                                }
                                else if (ll_bmcj_count >= 20)
                                {
                                    ls_msg += "\r\n两者不一致，请在shlx9中报修，否则将会导致您不能使用shlx9！";
                                    for (ll_i = 19; ll_i < ll_bmcj_count; ll_i++)
                                        MessageBox.Show((ll_bmcj_count - ll_i + 1).ToString() + "\r\n" + ls_msg, "部门车间不一致提示" + (ll_bmcj_count - ll_i + 1).ToString());
                                }
                                else if (ll_bmcj_count >= 8)
                                {
                                    ls_msg += "\r\n两者不一致，如果是临时使用请不予处理，否则请与信息部联系！";
                                    MessageBox.Show(ls_msg, "部门车间不一致提示");
                                }
                            }
                        }
                    }
                    if (ls_return.Substring(0, 2) == "p!")
                    {
                        if (ll_pass_ts >= 20) //20天提醒
                        {
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！\r\n1.建议同时修改windows的登录密码！\r\n2.建议同时修改邮箱密码！", "密码快过期提示");
                        }
                        else if (11 - ll_pass_ts <= 1)  // 10天提醒
                        {
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！1\r\n1.建议同时修改windows的登录密码！\r\n2.建议同时修改邮箱密码！", "密码快过期提示1");
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！2\r\n1.建议同时修改windows的登录密码！\r\n2.建议同时修改邮箱密码！", "密码快过期提示2");
                        }
                        else
                        {
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！4\r\n1.建议同时修改windows的登录密码！~r~n2.建议同时修改邮箱密码！", "密码快过期提示4");
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！5\r\n1.建议同时修改windows的登录密码！~r~n2.建议同时修改邮箱密码！", "密码快过期提示5");
                            MessageBox.Show("密码快过期提示，还有 " + ll_pass_ts + " 天！6\r\n1.建议同时修改windows的登录密码！~r~n2.建议同时修改邮箱密码！", "密码快过期提示6");
                        }
                    }

                    if (global.gu_pub1.gf_gnqx_1(global.g5_sys.username, "成本-详细成本-0浏览") == 1)
                        global.g5_shlx.chengben = true;

                    // 记录登录的用户名
                    //gu_pub1.f_txt_save(g5_sys.app_path,"pb9_save_ini","w_dljm","sle_1","username",g5_sys.winusername,g5_sys.username)
                    //wf_quanxian_user()
                    //if wf_quanxian_page() then open(w_xxzx_quanxian_page)
                    //            choose case g5_sys.chejian
                    //                case "销售部"
                    //                    // 不强行添加快捷方式
                    //                case else
                    //                    wf_desktop_lnk()
                    //            end choose
                    //            close(w_dljm);
                    //        else
                    //            g5_sys.username=""
                    //            g5_sys.truename=""
                    //            g5_shlx.chengben = false
                    //            messagebox("登录不成功提示7!",ls_return)
                    //            return
                    //        end if
                    //end choose
                    break;
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmModifyPwd frm = new frmModifyPwd();
            frm.ShowDialog();
        }
    }
}
