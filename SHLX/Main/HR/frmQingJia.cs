using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;
using CYQ.Data.UI;
using CYQ.Data.Table;

namespace Redsoft.HR
{
    public partial class frmQingJia : Form
    {
        public frmQingJia()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> cols = new Dictionary<string, string>();
        
        private void frmQingJia_Load(object sender, EventArgs e)
        {
            using (MAction action = new MAction("hr_qingjia_h"))
            {
                action.Select().Bind(dataGridView1);//查询所有数据并绑定到GridView中
                
            }
            
            cols.Add("qj_id", "请假ID");

            cols.Add("nian", "年份");

            cols.Add("hum_id", "编号");

            cols.Add("hum_name", "姓名");

            cols.Add("dep_code", "车间");

            cols.Add("gonghao", "工号");

            cols.Add("id_card", "身份证");

            cols.Add("rq_enter_1h", "入厂日期");

            cols.Add("zhuangtai", "状态");

            cols.Add("annual_leave", "可享年假");

            cols.Add("nianjia", "已请年假");

            cols.Add("gongshang", "工伤");

            cols.Add("hunjia", "婚假");

            cols.Add("sangjia", "丧假");

            cols.Add("bingjia", "病假");

            cols.Add("chanjia", "产假");

            cols.Add("shijia", "事假");

            cols.Add("hulijia", "护理假");

            cols.Add("kuanggong", "旷工");

            cols.Add("qitajia", "其它假");

            cols.Add("pingjungongzi", "平均工资");

            cols.Add("lrsj", "录入时间");

            cols.Add("xgsj", "修改时间");

            cols.Add("leijibingjia", "累计病假");
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.HeaderText=cols[c.HeaderText.ToLower()]; 
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            MDataTable dt;
            MAction action = new MAction("hr_qingjia_h");
            dt = action.Select();
            List<Panel> parents = new List<Panel>();
            parents.Add(panel1);
            dt.Rows[0].SetToAll("col", parents.ToArray());


        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            MAction action = new MAction("hr_qingjia_h");
            
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            MAction action = new MAction("hr_qingjia_h");
            action.BeginTransation();
            action.Set("qj_id", 1672);
            action.Set("nian", "2017-11-08");
            action.Set("hum_id", "8112");
            action.Insert(true);
            action.EndTransation();
        }
    }
}
