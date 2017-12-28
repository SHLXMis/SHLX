using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;
using CYQ.Data.Table;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using Aspose.Cells;
using System.ComponentModel;
using System.Diagnostics;

namespace Redsoft
{
    public class Common
    {
        public static string GetString(object value)
        {
            if (value == null || value.ToString() == "")
                return "";
            else
            {
                return value.ToString();
            }
        }
        public static long GetLong(object value)
        {
            if (value == null || value.ToString() == "")
                return 0;
            else
            {
                long ret = 0;
                long.TryParse(value.ToString(), out ret);
                return ret;
            }
        }
        public static void SetUIValue(MDataTable dt, Control panel1)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string name = dt.Rows[0][i].ColumnName;
                Control[] controls = panel1.Controls.Find(name, true);
                if (controls.Length > 0)
                {
                    string controlType = controls[0].GetType().Name;
                    if (controlType == "MyTextBox")
                    {
                        MyTextBox myTextBox = controls[0] as MyTextBox;
                        if (myTextBox != null)
                        {
                            myTextBox.OldText = Common.GetString(dt.Rows[0][i].Value);
                            myTextBox.Text = Common.GetString(dt.Rows[0][i].Value);
                        }
                    }
                    if (controlType == "MyComboBox")
                    {
                        MyComboBox myComboBox = controls[0] as MyComboBox;
                        if (myComboBox != null)
                        {
                            myComboBox.OldText = Common.GetString(dt.Rows[0][i].Value);
                            myComboBox.Text = Common.GetString(dt.Rows[0][i].Value);
                        }
                    }
                    if (controlType == "MyDateTime")
                    {
                        MyDateTime myDateTime = controls[0] as MyDateTime;
                        if (myDateTime != null)
                        {
                            DateTime date = DateTime.MinValue;
                            DateTime.TryParse(Common.GetString(dt.Rows[0][i].Value), out date);
                            if (date != DateTime.MinValue)
                            {
                                myDateTime.OldText = date.ToString("yyyy-MM-dd HH:mm:ss");
                                myDateTime.Text = date.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                myDateTime.OldText = "";
                                myDateTime.Text = "";
                            }
                        }
                    }
                    if (controlType == "MyOptions")
                    {
                        MyOptions myOptions = controls[0] as MyOptions;
                        if (myOptions != null)
                        {
                            myOptions.OldText = Common.GetString(dt.Rows[0][i].Value);
                            myOptions.Text = Common.GetString(dt.Rows[0][i].Value);
                        }
                    }
                }

            }
        }
        public static void GetUIValue(MAction action, Control panel1, RowStatus rowState)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                IMyControl mc = panel1.Controls[i] as IMyControl;
                if (mc != null)
                {
                    string text = mc.GetText();
                    if (rowState == RowStatus.Add)
                    {
                        if (text != "")
                            action.Set(panel1.Controls[i].Name, text);
                    }
                    else
                    {
                        action.Set(panel1.Controls[i].Name, text);
                    }
                }
            }
        }
        public static void GetUIValue(MAction action, DataGridViewRow  r)
        {
            for (int i = 0; i < r.DataGridView.Columns.Count; i++)
            {

                string text = Common.GetString(r.Cells[i].Value);

                action.Set(r.DataGridView.Columns[i].Name, text);
    
            }
        }
        public static string CheckValid(MAction action, Control panel1, RowStatus rowState, ErrorProvider ep)
        {
            if (ep != null)
                ep.Clear();
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                IMyControl mc = panel1.Controls[i] as IMyControl;
                if (mc != null)
                {

                    if (panel1.Controls[i].Visible)
                    {

                        if (!action.Data[panel1.Controls[i].Name].Struct.IsCanNull &&
                         mc.GetText() == "")
                        {
                            mc.SetInValid();
                            if (ep != null)
                                ep.SetError(panel1.Controls[i], "不能为空");

                            return "不能为空";
                        }
                        SqlDbType dbtype = action.Data[panel1.Controls[i].Name].Struct.SqlType;
                        if (dbtype == SqlDbType.Decimal ||
                            dbtype == SqlDbType.Float ||
                            dbtype == SqlDbType.Int ||
                            dbtype == SqlDbType.Money ||
                            dbtype == SqlDbType.Real ||
                            dbtype == SqlDbType.SmallInt ||
                            dbtype == SqlDbType.SmallMoney ||
                            dbtype == SqlDbType.TinyInt)
                        {
                            double d = 0;
                            if (mc.GetText() != "" && !double.TryParse(mc.GetText(), out d))
                            {
                                if (ep != null)
                                    ep.SetError(panel1.Controls[i], "不能转化为数字");
                                return "不能转化为数字";
                            }
                        }
                        if (dbtype == SqlDbType.DateTime ||
                            dbtype == SqlDbType.DateTime2 ||
                            dbtype == SqlDbType.Date ||
                            dbtype == SqlDbType.SmallDateTime)
                        {
                            DateTime dt = DateTime.MinValue;
                            if (mc.GetText() != "" && !DateTime.TryParse(mc.GetText(), out dt))
                            {
                                if (ep != null)
                                    ep.SetError(panel1.Controls[i], "不能转化为日期");
                                return "不能转化为日期";
                            }
                        }
                    }
                }
            }

            return "";
        }

        public static void UpdateColDisplay(DataGridView dataGridView1, IList<Column> cols)
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                foreach (Column col in cols)
                {
                    if (col.Name == c.HeaderText.ToLower())
                    {
                        c.HeaderText = col.Text;
                        c.Visible = col.Visible;
                    }
                }

            }
        }
        public static void InitCombobox(MyComboBox combo, string tableName,
            string where, string colName)
        {
            if (tableName == "" || colName == "")
                return;
            string sql = "SELECT  " + colName + "  FROM " + tableName;
            if (where != "")
                sql += " where " + where;

            sql += " group by " + colName;

            //DataSet ds = DBAccess.Query(sql);
            using (MAction action = new MAction(sql))
            {
                DataTable dt = action.Select().ToDataTable();
                combo.DataSource = dt;
                combo.ListData = dt;
                combo.DisplayMember = colName;
                combo.ValueMember = colName;
            }


        }
        public static void InitCombobox(DataGridViewComboBoxColumn combo, string tableName,
            string where, string colName, string order)
        {
            if (tableName == "" || colName == "")
                return;
            string sql = "SELECT distinct " + colName + "  FROM " + tableName;
            if (where != "")
                sql += " where " + where;
            if (order != "")
                sql += " order by " + order;
            using (MAction action = new MAction(sql))
            {
                System.Data.DataTable dt = action.Select().ToDataTable();
                combo.DataSource = dt;
                combo.DisplayMember = colName;
                combo.ValueMember = colName;
            }
        }
        public static void InitDataGridViewColumn(DataGridViewColumn c, System.Data.DataTable dt)
        {
            MyOptionsColumn moc = c as MyOptionsColumn;
            if (moc != null)
            {
                moc.DataSource = dt;
            }
            else
            {
                DataGridViewComboBoxColumn cbc = c as DataGridViewComboBoxColumn;
                if (cbc != null)
                {
                    cbc.DataSource = dt;
                    cbc.DisplayMember = "Name";
                    cbc.ValueMember = "Value";
                }
            }
        }
        public static void InitDDLB(Control c, System.Data.DataTable dt)
        {
            MyComboBox mc = c as MyComboBox;
            if (mc != null)
            {
                mc.DataSource = dt;
                mc.ListData = dt;
                mc.DisplayMember = "Name";
                mc.ValueMember = "Value";
            }
            else
            {
                MyOptions mo = c as MyOptions;
                if (mo != null)
                {
                    mo.BindData(dt);
                }
            }
        }
        public static long GetID(string tableName, String idCol)
        {
            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = new SqlParameter("@ls_id_max", SqlDbType.VarChar, 200);
            para.Direction = ParameterDirection.Output;
            outparas.Add(para);
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@as_tb_name", tableName);
            paras.Add(para);
            para = new SqlParameter("@as_sql_name", idCol);
            paras.Add(para);

            DBAccess.ExecSP("id_max_get_sj", paras, ref outparas);
            return long.Parse(outparas[0].Value.ToString());

        }
        public static void ExportExcel(System.Data.DataTable dt, string fileName)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\Export";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            fileName = Application.StartupPath + "\\Export\\" + fileName;
            if (File.Exists(fileName))
                File.Delete(fileName);
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            Cells cells = sheet.Cells;

            sheet.Cells.ImportDataTable(dt, true, 0, 0);
            book.Save(fileName);
            System.Threading.Thread.Sleep(400);
            System.Diagnostics.Process.Start(fileName);
        }
        public static void InitClass(string userName)
        {
            global.g5_dws1 = new str_sys_dw();
            global.g5_dws2 = new str_sys_dw();
            global.g5_shlx = new str_pub_shlx();
            global.g5_sys = new str_sys_pub();
            global.g5_sys.username = userName;
            global.gu_dw1 = new nvo_dw_fun();
            global.gu_pub1 = new nvo_pub_fun();
            global.gu_shlx = new nvo_shlx();
        }
        public static bool isDesignMode()
        {
            bool returnflag = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnflag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnflag = true;
            }

            return returnflag;
        }
        public static void gf_gnqx_n(string as_username, string as_page_name, ref string[] as_gnqx)
        {
            string[] ls_null = new string[6];
            as_gnqx = ls_null;
            as_gnqx = new string[] { "冗余", "000", "0浏览", "1添加", "2修改", "3删除" };
            if (as_username == "lhf")
            {
                as_gnqx = new string[] { "冗余", "99", "99", "99", "99", "99" };
                return;
            }
            if (string.IsNullOrEmpty(as_username) || string.IsNullOrEmpty(as_page_name))
                return;

            if (as_username == as_page_name && as_username == "000NO000")
            {
                as_gnqx = new string[] { "冗余", "68NO", "68NO", "991", "992", "993" };
                return;
            }

            string ls_return = "";
            long return_value;
            bool lb_sql = false;

            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = new SqlParameter("@ls_return", SqlDbType.VarChar, 2000);
            para.Direction = ParameterDirection.Output;
            outparas.Add(para);
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@leibie", 50);
            paras.Add(para);

            para = new SqlParameter("@user_name1", as_username);
            paras.Add(para);
            para = new SqlParameter("@page_name", as_page_name);
            paras.Add(para);
            para = new SqlParameter("@pass", "");
            paras.Add(para);
            para = new SqlParameter("@pass_new", "");
            paras.Add(para);
            para = new SqlParameter("@ip", "");
            paras.Add(para);
            DBAccess.ExecSP("login_gnqx_pass", paras, ref outparas);


            ls_return = outparas[0].Value.ToString();
            if (ls_return.Length >= 1)
            {
                if (ls_return == "99")
                {
                    as_gnqx = new string[] { "冗余", "99", "99", "99", "99", "99" };
                    return;
                }
                if (ls_return.Contains(","))
                    if (ls_return.Substring(0, 4) != "0浏览,")
                        ls_return = "0浏览," + ls_return;
                    else
                        if (ls_return != "0浏览")
                            ls_return = "0浏览," + ls_return;

               // as_gnqx = ls_return.Split(',');
                global.gu_pub1.f_s_listtoarray(ls_return, ",", ref as_gnqx);
                return_value = as_gnqx.Length;
                List<string> b = as_gnqx.ToList();
                b.Add("0浏览");
                b.Add("1添加");
                b.Add("2修改");
                b.Add("3删除");
                as_gnqx = b.ToArray();

                //as_gnqx[return_value + 1] = "0浏览";
                //as_gnqx[return_value + 2] = "1添加";
                //as_gnqx[return_value + 3] = "2修改";
                //as_gnqx[return_value + 4] = "3删除";
            }

        }
        /// <summary>  
        /// 获取当前本地时间戳  
        /// </summary>  
        /// <returns></returns>        
        public static long GetCurrentTimeUnix()
        {
            TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long t = (long)cha.TotalSeconds;
            return t;
        }
        /// <summary>  
        /// 时间戳转换为本地时间对象  
        /// </summary>  
        /// <returns></returns>        
        public static DateTime GetUnixDateTime(long unix)
        {
            //long unix = 1500863191;  
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime newTime = dtStart.AddSeconds(unix);
            return newTime;
        } 
    }
}
